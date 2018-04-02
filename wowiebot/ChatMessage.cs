using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace wowiebot
{
    class ChatMessage
    {
        protected string rawMessage { get; set; }

        public ChatMessage(string rawMessage)
        {
            this.rawMessage = rawMessage;
        }

        public virtual void handleMessage()
        {
            ChatHandler.getInstance().writeLineToFormBox(rawMessage);
        }

        override public string ToString()
        {
            return rawMessage;
        }
    }
}
