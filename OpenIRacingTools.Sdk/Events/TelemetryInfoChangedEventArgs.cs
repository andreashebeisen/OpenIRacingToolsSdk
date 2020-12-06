namespace OpenIRacingTools.Sdk.Events
{
    public class TelemetryInfoChangedEventArgs : ChangedEventArgs
    {
        public TelemetryInfoChangedEventArgs(TelemetryInfo info, double time)
            : base(time)
        {
            TelemetryInfo = info;
        }

        public TelemetryInfo TelemetryInfo { get; }
    }
}
