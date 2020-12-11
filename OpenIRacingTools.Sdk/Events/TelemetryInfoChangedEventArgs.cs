using OpenIRacingTools.Sdk.Model;

namespace OpenIRacingTools.Sdk.Events
{
    public class TelemetryInfoChangedEventArgs : ChangedEventArgs
    {
        public TelemetryInfoChangedEventArgs(TelemetryData info, double time)
            : base(time)
        {
            TelemetryInfo = info;
        }

        public TelemetryData TelemetryInfo { get; }
    }
}
