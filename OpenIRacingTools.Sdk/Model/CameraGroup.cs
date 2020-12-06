using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIRacingTools.Sdk.Model
{
    public class CameraGroup
    {
        public int GroupNum { get; private set; }
        public string GroupName { get; private set; }
        public List<CameraNg> Cameras { get; private set; }
        public bool IsScenic { get; set; }
    }
}
