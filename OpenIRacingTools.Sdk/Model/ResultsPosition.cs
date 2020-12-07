using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIRacingTools.Sdk.Model
{
    public class ResultsPosition
    {
        public int Position { get; set; }
        public int ClassPosition { get; set; }
        public int CarIdx { get; set; }
        public int Lap { get; set; }
        public double Time { get; set; }
        public int FastestLap { get; set; }
        public double FastestTime { get; set; }
        public int LapsLed { get; set; }
        public int LapsComplete { get; set; }
        public int JokerLapsComplete { get; set; }
        public double LapsDriven { get; set; }
        public int Incidents { get; set; }
        public int ReasonOutId { get; set; }
        public string ReasonOutStr { get; set; }
    }
}
