using System.Collections.Generic;

namespace OpenIRacingTools.Sdk.Model
{
    public class RadioInfo
    {
        public int SelectedRadioNum { get; private set; }
        public List<Radio> Radios { get; private set; }
    }
}
