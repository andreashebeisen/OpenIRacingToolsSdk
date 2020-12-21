using OpenIRacingTools.Sdk.Native.Enums;
using System;

namespace OpenIRacingTools.Sdk.Broadcast
{
    /// <summary>
    /// Provides control over the chat window.
    /// </summary>
    public class ChatControl : BroadcastBase
    {
        internal ChatControl(Sdk wrapper) : base(wrapper)
        {
        }

        /// <summary>
        /// Clear the chat window.
        /// </summary>
        public void Clear()
        {
            Broadcast(BroadcastMessageType.ChatCommand, (int)ChatCommand.Cancel, 0);
        }

        /// <summary>
        /// Start a reply to the last private message.
        /// </summary>
        public void Reply()
        {
            Broadcast(BroadcastMessageType.ChatCommand, (int)ChatCommand.Reply, 0);
        }

        /// <summary>
        /// Activate the chat window.
        /// </summary>
        public void Activate()
        {
            Broadcast(BroadcastMessageType.ChatCommand, (int)ChatCommand.BeginChat, 0);
        }

        /// <summary>
        /// Send a macro to the chat window.
        /// </summary>
        /// <param name="macro">The macro to send.</param>
        public void SendMacro(int macro)
        {
            if (macro < 0 || macro > 14)
            {
                throw new ArgumentOutOfRangeException("macro", "Macro must be between 0 and 14.");
            }

            Broadcast(BroadcastMessageType.ChatCommand, (int)ChatCommand.Macro, macro, 0);
        }
    }
}
