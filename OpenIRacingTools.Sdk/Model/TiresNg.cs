using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIRacingTools.Sdk.ModelNg
{
    public class TiresNg
    {
        public TireNg LeftFront { get; private set; }
        public TireNg LeftRear { get; private set; }
        public TireNg RightFront { get; private set; }
        public TireNg RightRear { get; private set; }
    }
}
