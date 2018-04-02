using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace wowiebot
{
    class ChatMessagePrivmsg : ChatMessage
    {
        private string sender;
        private bool senderIsMod;
        private bool senderIsBroadcaster;

        public ChatMessagePrivmsg(string rawMessage) : base(rawMessage)
        {

        }

        public override void handleMessage()
        {
            string messageParser = rawMessage;
            string chatMessage = messageParser.Substring(messageParser.LastIndexOf(":") + 1);
            messageParser = messageParser.Remove(messageParser.LastIndexOf(":"));
            string preambleFull = messageParser.Substring(messageParser.LastIndexOf(":") + 1);
            messageParser = messageParser.Remove(messageParser.LastIndexOf(":"));
            string[] preamble = preambleFull.Split(' ');
            string tochat;

            string[] sendingUser = preamble[0].Split('!');
            sender = sendingUser[0];
            tochat = sender + ": " + chatMessage;
            senderIsMod = messageParser.Contains("mod=1");

            if (sender != ChatHandler.getInstance().getBotNick())
            {
                ChatHandler.getInstance().messagesBetweenPeriodics++;
            }

            // sometimes the carriage returns get lost (??)
            if (tochat.Contains("\n") == false)
            {
                tochat = tochat + "\n";
            }

            if (chatMessage.StartsWith("\u0001ACTION"))
            {
                chatMessage = chatMessage.Replace("\u0001ACTION", "");
                chatMessage = chatMessage.Replace("\u0001", "");
                ChatHandler.getInstance().writeLineToFormBox("* " + sender + " " + chatMessage);
            }
            else
            {
                ChatHandler.getInstance().writeLineToFormBox("<" + (senderIsBroadcaster ? "~" : (senderIsMod ? "@" : "")) + sender + "> " + chatMessage);
            }

            if (chatMessage.StartsWith(Properties.Settings.Default.prefix))
            {
                string command;
                if (chatMessage.Contains(" "))
                    command = chatMessage.Substring(1, chatMessage.IndexOf(" ") - 1);
                else
                    command = chatMessage.Substring(1, chatMessage.Length - 1);

                command = command.ToLower();

                if (ChatHandler.getInstance().validCommands.Contains(command))
                {
                    string msg = ChatHandler.getInstance().commandsTable.Select("Command = '" + command + "'")[0].Field<string>("Message");
                    ChatHandler.getInstance().sendMessage(msg, chatMessage.Substring(chatMessage.IndexOf(" ") + 1));
                }

                else if (command == "wowie" && ChatHandler.getInstance().getBotNick() == "wowiebot")
                {
                    ChatHandler.getInstance().sendMessage("wowie");
                }
            }

            if (Properties.Settings.Default.enableLinkTitles)
            {
                ChatHandler.getInstance().printLinkTitles(chatMessage);
            }
        }
    }
}
