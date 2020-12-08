using System;

namespace OpenIRacingTools.Sdk.Model
{
    public class Result
    {
        public int Position { get; private set; }
        public int ClassPosition { get; private set; }
        public int CarIdx { get; private set; }
        public int FastestLap { get; private set; }
        public TimeSpan FastestTime { get; private set; }
    }
}
