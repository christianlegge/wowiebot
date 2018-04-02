using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wowiebot
{
    class ChatMessageJoin : ChatMessage
    {
        public ChatMessageJoin(string rawMessage) : base(rawMessage) { }
    }
}
