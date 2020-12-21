using OpenIRacingTools.Sdk.Native.Enums;

namespace OpenIRacingTools.Sdk.Broadcast
{
    /// <summary>
    /// Provides control over reloading of car textures.
    /// </summary>
    public class TextureControl : BroadcastBase
    {
        internal TextureControl(Sdk wrapper) : base(wrapper)
        {
        }

        /// <summary>
        /// Reload all car textures.
        /// </summary>
        public void Reload()
        {
            Broadcast(BroadcastMessageType.ReloadTextures, (int)ReloadTexturesMode.All, 0, 0);
        }

        /// <summary>
        /// Reload car textures for the specified car.
        /// </summary>
        /// <param name="carIdx">The ID (0-64) of the car to reload.</param>
        public void Reload(int carIdx)
        {
            Broadcast(BroadcastMessageType.ReloadTextures, (int)ReloadTexturesMode.CarIdx, carIdx, 0);
        }
    }
}
