using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIRacingTools.Sdk.Events
{
    public class TelemetryInfoChangedEventArgs : EventArgs
    {
        public TelemetryInfoChangedEventArgs(TelemetryInfo info, double sessionTime)
        {
            TelemetryInfo = info;
            UpdateTime = sessionTime;
        }

        public TelemetryInfo TelemetryInfo { get; }
        public double UpdateTime { get; }
    }
}
