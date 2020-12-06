using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIRacingTools.Sdk.Model.Types
{
    public struct Temperature
    {
        public Temperature(double celcius)
        {
            Celcius = celcius;
        }

        public double Celcius { get; private set; }
    }
}
