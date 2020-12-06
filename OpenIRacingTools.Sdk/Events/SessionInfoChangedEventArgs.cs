using OpenIRacingTools.Sdk.Model;

namespace OpenIRacingTools.Sdk.Events
{
    public class SessionInfoChangedEventArgs : ChangedEventArgs
    {
        public SessionInfoChangedEventArgs(SessionInfo info, double time)
            : base(time)
        {
            SessionInfo = info;
        }

        public SessionInfo SessionInfo { get; set; }
    }
}
