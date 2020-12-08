using System;

namespace OpenIRacingTools.Sdk.Model
{
    public class ResultsFastestLap
    {
        public int CarIdx { get; private set; }
        public int FastestLap { get; private set; }
        public TimeSpan FastestTime { get; private set; }
    }
}
