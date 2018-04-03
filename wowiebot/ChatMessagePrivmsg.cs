using System;
using System.Data;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using org.mariuszgromada.math.mxparser;

namespace wowiebot
{
    public class ChatMessagePrivmsg : ChatMessage
    {
        private string sender;
        private string sentMessage;
        private bool senderIsMod;
        private bool senderIsBroadcaster;

        public ChatMessagePrivmsg(string rawMessage) : base(rawMessage)
        {
            Regex regex = new Regex("@badges=(?<badges>.*);color=(?<color>.*);display-name=(?<displayname>.*);emotes=(?<emotes>.*);id=(?<id>.*);mod=(?<mod>.*);room-id=(?<roomid>.*);subscriber=(?<subscriber>.*);tmi-sent-ts=(?<tmisentts>.*);turbo=(?<turbo>.*);user-id=(?<userid>.*);user-type=(?<usertype>.*) :(?<sender>.*)!(.*)@(.*).tmi.twitch.tv PRIVMSG #(.*) :(?<message>.*)");
            Match match = regex.Match(rawMessage);
            sender = match.Groups["sender"].Value;
            sentMessage = match.Groups["message"].Value;
            senderIsMod = match.Groups["mod"].Value.Equals("1");
            senderIsBroadcaster = sender.Equals(ChatHandler.getInstance().getChannel());
        }

        public override void handleMessage()
        {
            string messageParser = rawMessage;
            string chatMessage = messageParser.Substring(messageParser.LastIndexOf(":") + 1);
            messageParser = messageParser.Remove(messageParser.LastIndexOf(":"));
            string preambleFull = messageParser.Substring(messageParser.LastIndexOf(":") + 1);
            messageParser = messageParser.Remove(messageParser.LastIndexOf(":"));
            string[] preamble = preambleFull.Split(' ');

            string[] sendingUser = preamble[0].Split('!');

            if (sender != ChatHandler.getInstance().getBotNick())
            {
                ChatHandler.getInstance().messagesBetweenPeriodics++;
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
                        if (senderHasPermission())
                        {
                            string msg = ChatHandler.getInstance().commandsTable.Select("Command = '" + command + "'")[0].Field<string>("Message");
                            msg = replaceVariables(msg, chatMessage.Substring(chatMessage.IndexOf(" ") + 1));
                            ChatHandler.getInstance().sendMessage(msg);
                        }

                        else
                        {
                            ChatHandler.getInstance().sendMessage("You don't have permission to do that.");
                        }
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

        private bool senderHasPermission()
        {
            return true;
        }

        public string getSender()
        {
            return sender;
        }

        public string getMessage()
        {
            return sentMessage;
        }

        public string replaceVariables(string commandText, string commandArgs)
        {
            JObject broadcastData = null;
            TimeSpan uptime = new TimeSpan(0);
            Quote q = null;

            foreach (String cmd in ChatHandler.getInstance().getMessageVars())
            {
                if (commandText.Contains("$" + cmd))
                {
                    switch (cmd)
                    {
                        case "QUOTE":
                            if (q == null)
                            {
                                q = QuoteHandler.getInstance().getQuote();
                            }
                            commandText = commandText.Replace("$QUOTE", q.getQuoteText());
                            break;
                        case "QNUM":
                            if (q == null)
                            {
                                q = QuoteHandler.getInstance().getQuote();
                            }
                            commandText = commandText.Replace("$QNUM", q.getQuoteNumber().ToString());
                            break;
                        case "ADDQUOTE":
                            QuoteHandler.getInstance().addQuote(commandArgs, sender, senderIsMod);
                            return null;
                        case "VOTEYES":
                            QuoteHandler.getInstance().voteYes(sender);
                            return null;
                        case "BROADCASTER":
                            commandText = commandText.Replace("$BROADCASTER", ChatHandler.getInstance().getChannel());
                            break;
                        case "SENDER":
                            commandText = commandText.Replace("$SENDER", sender);
                            break;
                        case "GAME":
                            if (broadcastData == null)
                            {
                                broadcastData = ChatHandler.getInstance().getBroadcastDataFromAPI();
                            }
                            commandText = commandText.Replace("$GAME", broadcastData.Property("game").Value.ToString());
                            break;
                        case "TITLE":
                            if (broadcastData == null)
                            {
                                broadcastData = ChatHandler.getInstance().getBroadcastDataFromAPI();
                            }
                            commandText = commandText.Replace("$TITLE", broadcastData.Property("status").Value.ToString());
                            break;
                        case "UPHOURS":
                            if (uptime.Ticks == 0)
                            {
                                uptime = ChatHandler.getInstance().getUptime();
                            }
                            commandText = commandText.Replace("$UPHOURS", uptime.Hours.ToString());
                            break;
                        case "UPMINUTES":
                            if (uptime.Ticks == 0)
                            {
                                uptime = ChatHandler.getInstance().getUptime();
                            }
                            commandText = commandText.Replace("$UPMINUTES", uptime.Minutes.ToString());
                            break;
                        case "8BALL":
                            commandText = commandText.Replace("$8BALL", ChatHandler.getInstance().get8BallResponse());
                            break;
                        case "CALCULATOR":
                            Expression e = new Expression(commandArgs);
                            string x = e.calculate().ToString();
                            commandText = commandText.Replace("$CALCULATOR", x);
                            break;
                        case "COMMANDS":
                            commandText = commandText.Replace("$COMMANDS", ChatHandler.getInstance().getHelpCommands());
                            break;

                    }
                }
            }

            return commandText;
        }
    }
}
