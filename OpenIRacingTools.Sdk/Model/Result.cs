using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIRacingTools.Sdk.Model
{
    public class Result
    {
        public int Position { get; private set; }
        public int ClassPosition { get; private set; }
        public int CarIdx { get; private set; }
        public int FastestLap { get; private set; }
        public double FastestTime { get; private set; }
    }
}
