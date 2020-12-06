using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIRacingTools.Sdk.Model
{
    public class RadioInfo
    {
        public int SelectedRadioNum { get; private set; }
        public List<RadioNg> Radios { get; private set; }
    }
}
