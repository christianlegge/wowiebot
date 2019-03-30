using System;
using System.Data;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
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
        public int bits = 0;
        public Dictionary<string, string> tags = new Dictionary<string, string>();

        public ChatMessagePrivmsg(string rawMessage) : base(rawMessage)
        {
            Regex r = new Regex(":(?<sender>[A-Za-z0-9_]*)!(.*)@(.*).tmi.twitch.tv PRIVMSG #(.*?) :(?<message>.*)");
            Match match = r.Match(rawMessage);
            parseTags(rawMessage);
            sender = match.Groups["sender"].Value;
            sentMessage = match.Groups["message"].Value;
            senderIsMod = tags["mod"].Equals("1");
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

                    if (senderHasPermission(command))
                    {
                        string args = getCommandArguments(sentMessage);
                        msg = replaceVariables(msg, args);
                        ChatHandler.getInstance().sendMessage(msg);
                    }

                    else
                    {
                        ChatHandler.getInstance().sendMessage(Properties.Settings.Default.noPermsMessage);
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

            else if (Properties.Settings.Default.enableLinkTitles)
            {
                ChatHandler.getInstance().printLinkTitles(sentMessage);
            }


            if (bits >= Properties.Settings.Default.bitsMessageThreshold)
            {
                string msg = Properties.Settings.Default.messageForBits;
                msg = msg.Replace("$COUNT", bits.ToString());
                msg = msg.Replace("$SENDER", sender);
                ChatHandler.getInstance().sendMessage(msg);
            }
        }

        private string getCommandArguments(string msg)
        {
            string[] splitMsg = msg.Split(" ".ToCharArray(), 2);
            return splitMsg.Length == 1 ? "" : splitMsg[1];
        }

        private string getIdFromYoutubeLink(Uri url)
        {
            Regex idRegex = new Regex("[A-Za-z0-9-_]{11}");
            if (url.Host.EndsWith("youtu.be") && idRegex.IsMatch(url.AbsolutePath.Remove(0, 1)))
            {
                return url.AbsolutePath.Remove(0, 1);
            }
            else if (url.Host.EndsWith("youtube.com"))
            {
                var getParams = HttpUtility.ParseQueryString(url.Query);
                if (idRegex.IsMatch(getParams["v"]))
                {
                    return getParams["v"];
                }
            }
            return null;
        }

        private bool senderHasPermission(string commandName)
        {
            List<string> allowedUsers = ChatHandler.getInstance().commandsDictionary[commandName].allowedUsers;
            if (allowedUsers.Count == 0 || allowedUsers.Contains(sender) || (allowedUsers.Contains("$mod") && senderIsMod) || senderIsBroadcaster)
            {
                return true;
            }
            else
            {
                return false;
            }
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
                            Uri ytlink = new Uri(commandArgs);
                            string id = getIdFromYoutubeLink(ytlink);
                            if (MainForm.songRequestForm == null)
                            {
                                commandText = "Unable to load video. Please tell the streamer to open the Song Requests window.";
                            }
                            else if (id != null)
                            {
                                SongRequest sr = new SongRequest(id, sender);
                                if (sr.embeddable == false)
                                {
                                    return "That video is not embeddable and can't be played in the bot window. Sorry!";
                                }
                                MainForm.songRequestForm.queueSong(sr);
                                return "Queued.";
                            }
                            else
                            {
                                commandText = "Unable to parse link.";
                            }
                            break;
                        case "QUEUETIME":
                            commandText = commandText.Replace("$QUEUETIME", MainForm.songRequestForm.getQueueLength().ToString());
                            break;
                    }
                }
            }

            return commandText;
        }

        private void parseTags(string message)
        {
            List<string> tagNames = new List<string>{ "badge-info", "badges", "bits", "color", "display-name", "emotes", "id", "message", "mod", "room-id", "subscriber", "tmi-sent-ts", "turbo", "user-id", "user-type"  };
            string allTags = message.Remove(message.IndexOf("tmi.twitch.tv PRIVMSG #"));

            foreach (string tag in tagNames)
            {
                Regex regex = new Regex("\\b"+tag+"=(.*?)[; ]");
                Match match = regex.Match(allTags);
                tags[tag] = match.Groups[1].Value;
            }
            
            try
            {
                bits = int.Parse(tags["bits"]);
            }
            catch (Exception e) { }
        }
    }
}
