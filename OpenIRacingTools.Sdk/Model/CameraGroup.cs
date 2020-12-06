using System.Collections.Generic;

namespace OpenIRacingTools.Sdk.Model
{
    public class CameraGroup
    {
        public int GroupNum { get; private set; }
        public string GroupName { get; private set; }
        public List<Camera> Cameras { get; private set; }
        public bool IsScenic { get; set; }
    }
}
