using OpenIRacingTools.Sdk.Model.Events;
using System;

namespace OpenIRacingTools.Sdk.Model
{
    public partial class Sim
    {
        public class RaceEventArgs : EventArgs
        {
            public RaceEventArgs(RaceEvent @event)
            {
                Event = @event;
            }

            public RaceEvent Event { get; }
        }
    }
}
