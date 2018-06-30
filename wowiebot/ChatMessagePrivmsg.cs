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
            Regex regex = new Regex("@badges=(?<badges>.*);color=(?<color>.*);display-name=(?<displayname>.*);emotes=(?<emotes>.*);id=(?<id>.*);mod=(?<mod>.*);room-id=(?<roomid>.*);subscriber=(?<subscriber>.*);tmi-sent-ts=(?<tmisentts>.*);turbo=(?<turbo>.*);user-id=(?<userid>.*);user-type=(?<usertype>.*) :(?<sender>.*)!(.*)@(.*).tmi.twitch.tv PRIVMSG #(.*?) :(?<message>.*)");
            Match match = regex.Match(rawMessage);
            sender = match.Groups["sender"].Value;
            sentMessage = match.Groups["message"].Value;
            senderIsMod = match.Groups["mod"].Value.Equals("1");
            senderIsBroadcaster = sender.Equals(ChatHandler.getInstance().getChannel());
        }

        public override void handleMessage()
        {
            if (sender != ChatHandler.getInstance().getBotNick())
            {
                ChatHandler.getInstance().messagesBetweenPeriodics++;
            }

            if (sentMessage.StartsWith("\u0001ACTION"))
            {
                sentMessage = sentMessage.Replace("\u0001ACTION", "");
                sentMessage = sentMessage.Replace("\u0001", "");
                ChatHandler.getInstance().writeLineToFormBox("* " + sender + " " + sentMessage);
            }
            else
            {
                ChatHandler.getInstance().writeLineToFormBox("<" + (senderIsBroadcaster ? "~" : (senderIsMod ? "@" : "")) + sender + "> " + sentMessage);
            }

            if (sentMessage.StartsWith(Properties.Settings.Default.prefix))
            {
                string command;
                if (sentMessage.Contains(" "))
                    command = sentMessage.Substring(1, sentMessage.IndexOf(" ") - 1);
                else
                    command = sentMessage.Substring(1, sentMessage.Length - 1);

                command = command.ToLower();

                try
                {
                    string msg = ChatHandler.getInstance().getMessageFromCommand(command);

                    if (senderHasPermission())
                    {
                        string args = getCommandArguments(sentMessage);
                        msg = replaceVariables(msg, args);
                        ChatHandler.getInstance().sendMessage(msg);
                    }

                    else
                    {
                        ChatHandler.getInstance().sendMessage("You don't have permission to do that.");
                    }
                }
                catch (Exception e)
                {
                    if (command == "wowie" && ChatHandler.getInstance().getBotNick() == "wowiebot")
                    {
                        ChatHandler.getInstance().sendMessage("wowie");
                    }
                }
            }
            
            if (Properties.Settings.Default.enableLinkTitles)
            {
                ChatHandler.getInstance().printLinkTitles(sentMessage);
            }
        }

        private string getCommandArguments(string msg)
        {
            string[] splitMsg = msg.Split(" ".ToCharArray(), 2);
            return splitMsg.Length == 1 ? "" : splitMsg[1];
        }

        private bool isValidYoutubeLink(string url)
        {
            return url.Contains("youtu");
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
                            commandText = commandText.Replace("$COMMANDS", ChatHandler.getInstance().commandsForHelp);
                            break;
                        case "SONGREQ":
                            if (MainForm.songRequestForm == null)
                            {
                                commandText = "Unable to load video. Please tell the streamer to open the Song Requests window.";
                            }
                            else if (isValidYoutubeLink(commandArgs))
                            {
                                Regex r = new Regex(@".*\b(?<id>[A-Za-z0-9-_]{11})\b.*");
                                Match m = r.Match(commandArgs);
                                string id = m.Groups["id"].Value;
                                MainForm.songRequestForm.queueSong(new SongRequest(id));
                                return "Queued.";
                            }
                            else
                            {
                                commandText = "Invalid link.";
                            }
                            break;
                    }
                }
            }

            return commandText;
        }
    }
}
