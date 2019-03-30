using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wowiebot
{
    class ChatMessagePing : ChatMessage
    {
        public ChatMessagePing(string rawMessage) : base(rawMessage) { }

        public override void handleMessage()
        {
            ChatHandler.sendPong();
        }
    }
}
