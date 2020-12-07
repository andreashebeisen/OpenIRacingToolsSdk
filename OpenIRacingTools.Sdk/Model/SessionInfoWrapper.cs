using System;
using System.Collections.Generic;

namespace OpenIRacingTools.Sdk.Model
{
    public class SessionInfoWrapper
    {
        public SessionInfoWrapper()
        {
            UpdateDate = DateTime.Now;
        }

        public DateTime UpdateDate { get; }
        public WeekendInfo WeekendInfo { get; private set; }
        public CameraInfo CameraInfo { get; private set; }
        public RadioInfo RadioInfo { get; private set; }
        public DriverInfo DriverInfo { get; private set; }
        public SplitTimeInfo SplitTimeInfo { get; private set; }
        public SessionInfo SessionInfo { get; private set; }
        public QualifyResultsInfo QualifyResultsInfo { get; private set; }
    }
}
