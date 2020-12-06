using System;

namespace OpenIRacingTools.Sdk.Events
{
    public abstract class ChangedEventArgs : EventArgs
    {
        protected ChangedEventArgs(double time)
        {
            UpdateTime = time;
        }

        /// <summary>
        /// Gets the time (in seconds) when this update occured.
        /// </summary>
        public double UpdateTime { get; }
    }
}
