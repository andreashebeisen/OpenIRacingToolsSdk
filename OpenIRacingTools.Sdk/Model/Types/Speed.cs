using System;

namespace OpenIRacingTools.Sdk.Model.Types
{
    public struct Speed
    {
        public Speed(double value, string unit = "kph")
        {
            switch (unit)
            {
                case "km/h":
                case "kph":
                    KpH = value;
                    break;

                case "m/s":
                    KpH = value / 3.6;
                    break;

                default:
                    throw new NotSupportedException($"Unit {unit} is not supported.");
            }
        }

        public double KpH { get; private set; }
    }
}
