using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wowiebot
{
    class ChatMessageUsernotice : ChatMessage
    {
        private string sender;
        private string sentMessage;

        public ChatMessageUsernotice(string rawMessage) : base(rawMessage)
        {
            Regex r = new Regex(":tmi.twitch.tv USERNOTICE #(.*?) :(?<message>.*)");
            Match match = r.Match(rawMessage);
            parseTags(rawMessage);
            sender = match.Groups["sender"].Value;
            sentMessage = match.Groups["message"].Value;
        }

        public override void handleMessage()
        {
            if (tags["msg-id"] == "sub" || tags["msg-id"] == "resub")
            {
                string reply = Properties.Settings.Default.subResponse;
                reply = reply.Replace("$SENDER", tags["display-name"]);
                reply = reply.Replace("$BROADCASTER", ChatHandler.getChannel());
                reply = reply.Replace("$MONTHS", tags["msg-param-cumulative-months"]);
                ChatHandler.sendMessage(reply);
            }
            else if (tags["msg-id"] == "subgift" || tags["msg-id"] == "anonsubgift")
            {
                string reply = Properties.Settings.Default.giftSubResponse;
                reply = reply.Replace("$SENDER", tags["display-name"]);
                reply = reply.Replace("$BROADCASTER", ChatHandler.getChannel());
                reply = reply.Replace("$MONTHS", tags["msg-param-months"]);
                reply = reply.Replace("$RECIPIENT", tags["msg-param-recipient-display-name"]);
                ChatHandler.sendMessage(reply);
            }
            else if (tags["msg-id"] == "raid")
            {
                string reply = Properties.Settings.Default.raidResponse;
                reply = reply.Replace("$SENDER", tags["msg-param-displayName"]);
                reply = reply.Replace("$BROADCASTER", ChatHandler.getChannel());
                reply = reply.Replace("$COUNT", tags["msg-param-viewerCount"]);
                ChatHandler.sendMessage(reply);
            }
        }
    }
}
