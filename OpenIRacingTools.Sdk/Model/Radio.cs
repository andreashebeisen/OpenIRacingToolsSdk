using System.Collections.Generic;

namespace OpenIRacingTools.Sdk.Model
{
    public class Radio
    {
        public int RadioNum { get; private set; }
        public int HopCount { get; private set; }
        public int TunedToFrequencyNum { get; private set; }
        public bool ScanningIsOn { get; private set; }
        public List<RadioFrequency> Frequencies { get; private set; }
    }
}
