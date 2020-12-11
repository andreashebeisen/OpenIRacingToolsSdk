using OpenIRacingTools.Sdk.Model;

namespace OpenIRacingTools.Sdk.Events
{
    public class SessionInfoChangedEventArgs : ChangedEventArgs
    {
        public SessionInfoChangedEventArgs(SessionData info, double time)
            : base(time)
        {
            SessionInfo = info;
        }

        public SessionData SessionInfo { get; set; }
    }
}
