using OpenIRacingTools.Sdk.Broadcast;
using OpenIRacingTools.Sdk.Events;
using OpenIRacingTools.Sdk.Model;
using OpenIRacingTools.Sdk.Native;
using OpenIRacingTools.Sdk.Yaml;
using System;
using System.Threading;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace OpenIRacingTools.Sdk
{
    /// <summary>
    /// Provides a useful wrapper of the iRacing SDK.
    /// </summary>
    public sealed partial class SdkWrapper
    {
        #region Fields

        internal readonly iRacingSDK sdk;
        private readonly SynchronizationContext context;
        private int waitTime;
        private Mutex readMutex;

        private CancellationTokenSource runningCancellationToken;

        private IDeserializer deserializer;

        private TaskCompletionSource connectionSource;
        private TaskCompletionSource firstDataSource;

        #endregion

        /// <summary>
        /// Creates a new instance of the SdkWrapper.
        /// </summary>
        public SdkWrapper()
        {
            context = SynchronizationContext.Current;
            sdk = new iRacingSDK();
            EventRaiseType = EventRaiseTypes.CurrentThread;

            readMutex = new Mutex(false);

            TelemetryUpdateFrequency = 60;

            Replay = new ReplayControl(this);
            Camera = new CameraControl(this);
            PitCommands = new PitCommandControl(this);
            Chat = new ChatControl(this);
            Textures = new TextureControl(this);
            TelemetryRecording = new TelemetryRecordingControl(this);

            deserializer = new DeserializerBuilder()
                .IgnoreUnmatchedProperties()
                .WithTypeConverter(new NumericTypeConverter())
                .WithTypeConverter(new DoubleUnitTypeConverter())
                .WithTypeConverter(new BooleanTypeConverter())
                .WithTypeConverter(new EnumTypeConverter())
                .WithTypeConverter(new ColorTypeConverter())
                .WithTypeConverter(new TimeSpanTypeConverter())
                .Build();
        }

        #region Properties

        /// <summary>
        /// Gets or sets how events are raised. Choose 'CurrentThread' to raise the events on the thread you created this object on (typically the UI thread), 
        /// or choose 'BackgroundThread' to raise the events on a background thread, in which case you have to delegate any UI code to your UI thread to avoid cross-thread exceptions.
        /// </summary>
        public EventRaiseTypes EventRaiseType { get; set; }

        /// <summary>
        /// Is the main loop running?
        /// </summary>
        public bool IsRunning => runningCancellationToken != null;

        /// <summary>
        /// Is the SDK connected to iRacing?
        /// </summary>
        public bool IsConnected { get; private set; }

        public string SerializationErrorLogsPath { get; set; }

        private int telemetryUpdateFrequency;
        /// <summary>
        /// Gets or sets the number of times the telemetry info is updated per second. The default and maximum is 60 times per second.
        /// </summary>
        public int TelemetryUpdateFrequency
        {
            get { return telemetryUpdateFrequency; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("TelemetryUpdateFrequency must be at least 1.");
                }

                if (value > 60)
                {
                    throw new ArgumentOutOfRangeException("TelemetryUpdateFrequency cannot be more than 60.");
                }

                telemetryUpdateFrequency = value;

                waitTime = (int)Math.Floor(1000f / value) - 1;
            }
        }

        /// <summary>
        /// The time in milliseconds between each check if iRacing is running. Use a low value (hundreds of milliseconds) to respond quickly to iRacing startup.
        /// Use a high value (several seconds) to conserve resources if an immediate response to startup is not required.
        /// </summary>
        public int ConnectSleepTime { get; set; } = 1000;

        public SessionInfoWrapper SessionInfo { get; private set; }

        public TelemetryInfo TelemetryInfo { get; private set; }

        public string SessionInfoRaw { get; private set; }

        #region Broadcast messages

        /// <summary>
        /// Controls the replay playback system.
        /// </summary>
        public ReplayControl Replay { get; private set; }

        /// <summary>
        /// Provides control over the replay camera and where it is focused.
        /// </summary>
        public CameraControl Camera { get; private set; }

        /// <summary>
        /// Provides control over the pit commands.
        /// </summary>
        public PitCommandControl PitCommands { get; private set; }

        /// <summary>
        /// Provides control over the chat window.
        /// </summary>
        public ChatControl Chat { get; private set; }

        /// <summary>
        /// Provides control over reloading of car textures.
        /// </summary>
        public TextureControl Textures { get; private set; }

        /// <summary>
        /// Provides control over the telemetry recording system.
        /// </summary>
        public TelemetryRecordingControl TelemetryRecording { get; private set; }

        #endregion

        #endregion

        #region Methods

        /// <summary>
        /// Connects to iRacing and starts the main loop in a background thread.
        /// </summary>
        public StartResult Start()
        {
            // Stop the current looper
            Stop();

            // Create new cancellation token and run the looper
            runningCancellationToken = new CancellationTokenSource();
            Task.Run(() => Loop(runningCancellationToken.Token), runningCancellationToken.Token);

            connectionSource = new TaskCompletionSource();
            firstDataSource = new TaskCompletionSource();

            return new StartResult(connectionSource.Task, firstDataSource.Task);
        }

        /// <summary>
        /// Stops the main loop
        /// </summary>
        public void Stop()
        {
            if (!IsRunning)
            {
                return;
            }

            // Cancel the current operation
            runningCancellationToken.Cancel(true);

            // Wait for cancellation to complete to avoid race condition with re-start
            WaitHandle.WaitAny(new[] { runningCancellationToken.Token.WaitHandle });

            runningCancellationToken = null;
        }

        private void Loop(CancellationToken cancellationToken)
        {
            int lastUpdate = -1;
            bool hasConnected = false;

            while (!cancellationToken.IsCancellationRequested)
            {
                // Check if we can find the sim
                if (sdk.IsConnected())
                {
                    if (!IsConnected)
                    {
                        // If this is the first time, raise the Connected event
                        RaiseEvent(OnConnected, EventArgs.Empty);
                        connectionSource.SetResult();
                    }

                    hasConnected = true;
                    IsConnected = true;

                    readMutex.WaitOne(8);

                    // Update telemetry info

                    TelemetryInfo = new TelemetryInfo(sdk);

                    var telArgs = new TelemetryInfoChangedEventArgs(TelemetryInfo, (double)sdk.GetData("SessionTime"));
                    RaiseEvent(OnTelemetryInfoChanged, telArgs);

                    // Update session info

                    int newUpdate = sdk.Header.SessionInfoUpdate;
                    if (newUpdate != lastUpdate)
                    {
                        SessionInfoRaw = sdk.GetSessionInfo();
                        SessionInfo = deserializer.Deserialize<SessionInfoWrapper>(SessionInfoRaw);

                        var args = new SessionInfoChangedEventArgs(SessionInfo, (double)sdk.GetData("SessionTime"));
                        RaiseEvent(OnSessionInfoChanged, args);

                        if (lastUpdate == -1)
                        {
                            firstDataSource.SetResult();
                        }

                        lastUpdate = newUpdate;
                    }
                }
                else if (hasConnected)
                {
                    // We have already been initialized before, so the sim is closing
                    RaiseEvent(OnDisconnected, EventArgs.Empty);

                    sdk.Shutdown();
                    lastUpdate = -1;
                    IsConnected = false;
                    hasConnected = false;
                }
                else
                {
                    // Have not been initialized before and there is no connection. Try to find the sim.
                    IsConnected = false;
                    hasConnected = false;

                    sdk.Startup();
                }

                // Sleep for a short amount of time until the next update is available
                if (IsConnected)
                {
                    if (waitTime <= 0 || waitTime > 1000)
                    {
                        waitTime = 15;
                    }

                    Thread.Sleep(waitTime);
                }
                else
                {
                    // Not connected yet, no need to check every 16 ms, let's try again in some time
                    Thread.Sleep(ConnectSleepTime);
                }
            }

            sdk.Shutdown();
            IsConnected = false;
        }

        #endregion

        #region Events

        /// <summary>
        /// Event raised when the sim outputs telemetry information (60 times per second).
        /// </summary>
        public event EventHandler<TelemetryInfoChangedEventArgs> TelemetryInfoChanged;

        /// <summary>
        /// Event raised when the sim refreshes the session info (few times per minute).
        /// </summary>
        public event EventHandler<SessionInfoChangedEventArgs> SessionInfoChanged;

        /// <summary>
        /// Event raised when the SDK detects the sim for the first time.
        /// </summary>
        public event EventHandler Connected;

        /// <summary>
        /// Event raised when the SDK no longer detects the sim (sim closed).
        /// </summary>
        public event EventHandler Disconnected;

        private void RaiseEvent<T>(Action<T> del, T e)
            where T : EventArgs
        {
            var callback = new SendOrPostCallback(obj => del(obj as T));

            if (context != null && EventRaiseType == EventRaiseTypes.CurrentThread)
            {
                // Post the event method on the thread context, this raises the event on the thread on which the SdkWrapper object was created
                context.Post(callback, e);
            }
            else
            {
                // Simply invoke the method, this raises the event on the background thread that the SdkWrapper created
                // Care must be taken by the user to avoid cross-thread operations
                callback.Invoke(e);
            }
        }

        private void OnTelemetryInfoChanged(TelemetryInfoChangedEventArgs e) => TelemetryInfoChanged?.Invoke(this, e);
        private void OnSessionInfoChanged(SessionInfoChangedEventArgs e) => SessionInfoChanged?.Invoke(this, e);

        private void OnConnected(EventArgs e) => Connected?.Invoke(this, e);

        private void OnDisconnected(EventArgs e) => Disconnected?.Invoke(this, e);

        #endregion


        internal int BroadcastMessage(BroadcastMessageTypes msg, int var1, int var2)
        {
            return sdk.BroadcastMessage(msg, var1, var2);
        }

        internal int BroadcastMessage(BroadcastMessageTypes msg, int var1, int var2, int var3)
        {
            return sdk.BroadcastMessage(msg, var1, var2, var3);
        }
    }
}
