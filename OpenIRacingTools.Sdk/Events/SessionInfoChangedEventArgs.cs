using OpenIRacingTools.Sdk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIRacingTools.Sdk.Events
{
    public class SessionInfoChangedEventArgs : EventArgs
    {
        public SessionInfoChangedEventArgs(SessionInfoNg info, double sessionTime)
        {
            SessionInfo = info;
            UpdateTime = sessionTime;
        }

        public SessionInfoNg SessionInfo { get; set; }
        public double UpdateTime { get; }
    }
}
