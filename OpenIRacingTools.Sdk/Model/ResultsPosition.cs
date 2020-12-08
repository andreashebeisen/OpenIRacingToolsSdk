using System;

namespace OpenIRacingTools.Sdk.Model
{
    public class ResultsPosition
    {
        public int Position { get; private set; }
        public int ClassPosition { get; private set; }
        public int CarIdx { get; private set; }
        public int Lap { get; private set; }
        public TimeSpan Time { get; private set; }
        public int FastestLap { get; private set; }
        public TimeSpan FastestTime { get; private set; }
        public int LapsLed { get; private set; }
        public int LapsComplete { get; private set; }
        public int JokerLapsComplete { get; private set; }
        public double LapsDriven { get; private set; }
        public int Incidents { get; private set; }
        public int ReasonOutId { get; private set; }
        public string ReasonOutStr { get; private set; }
    }
}
