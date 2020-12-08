using OpenIRacingTools.Sdk.Model.Enums;
using System.Collections.Generic;

namespace OpenIRacingTools.Sdk.Model
{
    public class Session
    {
        public int SessionNum { get; private set; }
        public int? SessionLaps { get; private set; }
        public double? SessionTime { get; private set; }
        public int SessionNumLapsToAvg { get; private set; }
        public SessionType SessionType { get; private set; }
        public TrackUsageType SessionTrackRubberState { get; private set; }
        public string SessionName { get; private set; }
        public string SessionSubType { get; private set; }
        public bool SessionSkipped { get; private set; }
        public bool SessionRunGroupsUsed { get; private set; }
        public List<ResultsPosition> ResultsPositions { get; private set; }
        public List<ResultsFastestLap> ResultsFastestLap { get; private set; }
        public double ResultsAverageLapTime { get; private set; }
        public int ResultsNumCautionFlags { get; private set; }
        public int ResultsNumCautionLaps { get; private set; }
        public int ResultsNumLeadChanges { get; private set; }
        public int ResultsLapsComplete { get; private set; }
        public bool ResultsOfficial { get; private set; }
    }
}
