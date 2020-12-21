using OpenIRacingTools.Sdk.Native.Enums;

namespace OpenIRacingTools.Sdk.Broadcast
{
    public abstract class BroadcastBase
    {
        private readonly Sdk _wrapper;

        internal BroadcastBase(Sdk wrapper)
        {
            _wrapper = wrapper;
        }

        protected void Broadcast(BroadcastMessageType type, int var1, int var2)
        {
            if (!_wrapper.IsConnected)
            {
                return;
            }

            _wrapper.BroadcastMessage(type, var1, var2);
        }

        protected void Broadcast(BroadcastMessageType type, int var1, int var2, int var3)
        {
            if (!_wrapper.IsConnected)
            {
                return;
            }

            _wrapper.BroadcastMessage(type, var1, var2, var3);
        }
    }
}
