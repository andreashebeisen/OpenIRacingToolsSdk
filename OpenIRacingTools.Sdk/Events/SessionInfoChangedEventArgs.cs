using OpenIRacingTools.Sdk.Model;

namespace OpenIRacingTools.Sdk.Events
{
    public class SessionInfoChangedEventArgs : ChangedEventArgs
    {
        public SessionInfoChangedEventArgs(SessionInfoWrapper info, double time)
            : base(time)
        {
            SessionInfo = info;
        }

        public SessionInfoWrapper SessionInfo { get; set; }
    }
}
