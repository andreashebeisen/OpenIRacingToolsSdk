using System.Collections.Generic;
using System.Linq;

namespace OpenIRacingTools.Sdk.Model
{
    public class SessionInfo
    {
        public List<Session> Sessions { get; private set; }
        public Session CurrentSession => Sessions.LastOrDefault(x => x.ResultsPositions != null);
    }
}
