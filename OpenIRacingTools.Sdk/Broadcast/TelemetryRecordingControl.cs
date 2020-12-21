using OpenIRacingTools.Sdk.Native;
using OpenIRacingTools.Sdk.Native.Enums;

namespace OpenIRacingTools.Sdk.Broadcast
{
    /// <summary>
    /// Provides control over the telemetry recording system.
    /// </summary>
    public class TelemetryRecordingControl : BroadcastBase
    {
        internal TelemetryRecordingControl(Sdk wrapper) : base(wrapper)
        {
        }

        /// <summary>
        /// Start recording telemetry.
        /// </summary>
        public void Start()
        {
            Broadcast(BroadcastMessageType.TelemCommand, (int)TelemCommandModeTypes.Start, 0, 0);
        }

        /// <summary>
        /// Stop recording telemetry.
        /// </summary>
        public void Stop()
        {
            Broadcast(BroadcastMessageType.TelemCommand, (int)TelemCommandModeTypes.Stop, 0, 0);
        }

        /// <summary>
        /// Start a new telemetry file.
        /// </summary>
        public void StartNewFile()
        {
            Broadcast(BroadcastMessageType.TelemCommand, (int)TelemCommandModeTypes.Restart, 0, 0);
        }
    }
}
