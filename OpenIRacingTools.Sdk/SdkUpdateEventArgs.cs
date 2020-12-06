using System;

namespace OpenIRacingTools.Sdk
{
    public class SdkUpdateEventArgs : EventArgs
    {
        public SdkUpdateEventArgs(double time)
        {
            UpdateTime = time;
        }

        /// <summary>
        /// Gets the time (in seconds) when this update occured.
        /// </summary>
        public double UpdateTime { get; }
    }
}
