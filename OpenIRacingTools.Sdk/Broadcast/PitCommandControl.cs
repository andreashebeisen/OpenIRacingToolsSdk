using OpenIRacingTools.Sdk.Native.Enums;

namespace OpenIRacingTools.Sdk.Broadcast
{
    /// <summary>
    /// Provides control over the pit commands.
    /// </summary>
    public class PitCommandControl : BroadcastBase
    {
        internal PitCommandControl(Sdk wrapper) : base(wrapper)
        {
        }

        /// <summary>
        /// Schedule to add the specified amount of fuel (in liters) in the next pitstop.
        /// </summary>
        /// <param name="amount">The amount of fuel (in liters) to add. Use 0 to leave at current value.</param>
        public void AddFuel(int amount)
        {
            Broadcast(BroadcastMessageType.PitCommand, (int)PitCommand.Fuel, amount, 0);
        }

        private void ChangeTire(PitCommand type, int pressure)
        {
            Broadcast(BroadcastMessageType.PitCommand, (int)type, pressure);
        }

        /// <summary>
        /// Schedule to change one or more tires and set their new pressures.
        /// </summary>
        /// <param name="change">The scheduled tire changes.</param>
        public void ChangeTires(TireChange change)
        {
            if (change.LeftFront != null && change.LeftFront.Change)
            {
                ChangeTire(PitCommand.LF, change.LeftFront.Pressure);
            }

            if (change.RightFront != null && change.RightFront.Change)
            {
                ChangeTire(PitCommand.RF, change.RightFront.Pressure);
            }

            if (change.LeftRear != null && change.LeftRear.Change)
            {
                ChangeTire(PitCommand.LR, change.LeftRear.Pressure);
            }

            if (change.RightRear != null && change.RightRear.Change)
            {
                ChangeTire(PitCommand.RR, change.RightRear.Pressure);
            }
        }

        /// <summary>
        /// Schedule to use a windshield tear-off in the next pitstop.
        /// </summary>
        public void Tearoff()
        {
            Broadcast(BroadcastMessageType.PitCommand, (int)PitCommand.WS, 0);
        }

        /// <summary>
        /// Schedule to use a fast repair in the next pitstop.
        /// </summary>
        public void FastRepair()
        {
            Broadcast(BroadcastMessageType.PitCommand, (int)PitCommand.FastRepair, 0);
        }

        /// <summary>
        /// Clear all pit commands.
        /// </summary>
        public void Clear()
        {
            Broadcast(BroadcastMessageType.PitCommand, (int)PitCommand.Clear, 0);
        }

        /// <summary>
        /// Clear all tire changes.
        /// </summary>
        public void ClearTires()
        {
            Broadcast(BroadcastMessageType.PitCommand, (int)PitCommand.ClearTires, 0);
        }

        public class Tire
        {
            internal Tire() { }

            /// <summary>
            /// Whether or not to change this tire.
            /// </summary>
            public bool Change { get; set; }

            /// <summary>
            /// The new pressure (in kPa) of this tire.
            /// </summary>
            public int Pressure { get; set; }
        }

        /// <summary>
        /// Encapsulates scheduled tire changes for each of the four tires separately.
        /// </summary>
        public class TireChange
        {
            public TireChange()
            {
                LeftFront = new Tire();
                RightFront = new Tire();
                LeftRear = new Tire();
                RightRear = new Tire();
            }

            public Tire LeftFront { get; set; }
            public Tire RightFront { get; set; }
            public Tire LeftRear { get; set; }
            public Tire RightRear { get; set; }
        }


    }
}
