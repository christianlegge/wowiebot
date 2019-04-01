using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace wowiebot
{
    public class ChatMessage
    {
        public Dictionary<string, string> tags = new Dictionary<string, string>();

        protected string rawMessage { get; set; }

        public ChatMessage(string rawMessage)
        {
            this.rawMessage = rawMessage;
        }

        public virtual void handleMessage()
        {
#if DEBUG
            ChatHandler.writeLineToFormBox(rawMessage);
#endif
        }

        override public string ToString()
        {
            return rawMessage;
        }

        protected void parseTags(string message)
        {
            string parsing = message;
            Regex r = new Regex("^@?([A-Za-z-]+)=([^; ]*)[; ]");
            while (r.IsMatch(parsing))
            {
                Match m = r.Match(parsing);
                string tag = m.Groups[1].Value;
                string match = m.Groups[2].Value;
                parsing = parsing.Remove(0, m.Value.Length);
                tags[tag] = match;
            }
        }
    }
}
