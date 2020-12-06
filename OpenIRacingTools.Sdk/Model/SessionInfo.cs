using System;

namespace OpenIRacingTools.Sdk.Model
{
    public class SessionInfo
    {
        public SessionInfo()
        {
            UpdateDate = DateTime.Now;
        }

        public DateTime UpdateDate { get; }
        public WeekendInfo WeekendInfo { get; private set; }
        public CameraInfo CameraInfo { get; private set; }
        public RadioInfo RadioInfo { get; private set; }
        public DriverInfo DriverInfo { get; private set; }
        public SplitTimeInfo SplitTimeInfo { get; private set; }
    }
}
