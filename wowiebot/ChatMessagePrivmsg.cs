using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wowiebot
{
    class ChatMessagePrivmsg : ChatMessage
    {
        public ChatMessagePrivmsg(string rawMessage) : base(rawMessage)
        {

        }
        public void handleMessage()
        {
            throw new NotImplementedException();
        }
    }
}
