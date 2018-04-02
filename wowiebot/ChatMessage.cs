using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wowiebot
{
    class ChatMessage
    {
        private string rawMessage { get; set; }

        public ChatMessage(string rawMessage)
        {
            this.rawMessage = rawMessage;
        }

        public void handleMessage()
        {

        }

        override public string ToString()
        {
            return rawMessage;
        }
    }
}
