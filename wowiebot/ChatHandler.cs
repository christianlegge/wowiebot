using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Timers;
using System.Text.RegularExpressions;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using org.mariuszgromada.math.mxparser;

namespace wowiebot
{
    class ChatHandler
    {
        private static ChatHandler instance = new ChatHandler();
        public static ChatHandler getInstance()
        {
            return instance;
        }

        private byte[] data = new byte[512];
        private string channel;
        private string botNick;
        private string botOauth;
        private MainForm mainForm;
        private NetworkStream stream;
        private List<string> quotes;
        private Dictionary<System.Timers.Timer, String> periodicMessageTimers;
        private Dictionary<System.Timers.Timer, System.Timers.Timer> offsetTimers;
        private Random rnd = new Random();
        private int lastQuote = -1;
        private int lastChoice = -1;
        private bool addingQuote = false;
        private List<string> quoteAdders = new List<string>();
        private string quoteToAdd;
        private System.Timers.Timer quoteTimer = new System.Timers.Timer(60000);
        private List<string> eightBallChoices;
        public List<string> validCommands = new List<string>();
        private List<bool> displayCommandsInHelp = new List<bool>();
        private string userID;
        private List<string> messageVars = new List<string>(new string[] { "QUOTE", "QNUM", "ADDQUOTE", "VOTEYES", "BROADCASTER", "SENDER", "GAME", "TITLE", "UPHOURS", "UPMINUTES", "8BALL", "CALCULATOR", "COMMANDS" });
        public DataTable commandsTable;
        private DataTable periodicMessagesTable;
        private String helpCommands;
        private String sender;
        private bool senderIsMod;
        private bool botIsMod;
        public int messagesBetweenPeriodics = 0;
        private StreamReader streamReader;

        private bool willDisconnect = false;

        public void writeLineToFormBox(string msg)
        {
            mainForm.writeToServerOutputTextBox(msg + "\r\n");
        }

        public int start(MainForm pMainForm, string pChannel, string pNick, string pOauth)
        {
            mainForm = pMainForm;
            channel = pChannel.ToLower();
            botNick = pNick;
            botOauth = pOauth;

            commandsTable = JsonConvert.DeserializeObject<DataTable>(Properties.Settings.Default.commandsDataTableJson);
            periodicMessagesTable = JsonConvert.DeserializeObject<DataTable>(Properties.Settings.Default.periodicMessagesDataTableJson);

            if (periodicMessagesTable == null)
            {
                periodicMessagesTable = new DataTable();
            }

            populateValidCommands();

            createPeriodicMessagesTimers();

            if (validCommands.Contains("title") || validCommands.Contains("uptime"))
            {
                try
                {
                    getUserIDFromAPI();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message + e.StackTrace, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 1;
                }
            }

            return runBot();

        }

        private void createPeriodicMessagesTimers()
        {
            periodicMessageTimers = new Dictionary<System.Timers.Timer, string>();
            offsetTimers = new Dictionary<System.Timers.Timer, System.Timers.Timer>();
            DataRow[] periodicRows = periodicMessagesTable.Select("enabled = true");
            foreach (DataRow row in periodicRows)
            {
                System.Timers.Timer t = new System.Timers.Timer(row.Field<double>("Period") * 1000 * 60);
                t.Elapsed += PeriodicMessageTimer_Elapsed;
                if (row.Field<double>("Offset") > 0)
                {
                    System.Timers.Timer offsetTimer = new System.Timers.Timer(row.Field<double>("Offset") * 1000 * 60);
                    offsetTimer.Elapsed += OffsetTimer_Elapsed;
                    offsetTimers.Add(offsetTimer, t);
                    offsetTimer.Start();
                }
                else
                {
                    t.Start();
                }
                periodicMessageTimers.Add(t, row.Field<string>("Message"));
            }
        }

        private void OffsetTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (stream != null && messagesBetweenPeriodics >= Properties.Settings.Default.minimumMessagesBetweenPeriodic)
            {
                sendMessage(periodicMessageTimers[offsetTimers[(System.Timers.Timer)sender]]);
                messagesBetweenPeriodics = 0;
            }
            offsetTimers[(System.Timers.Timer)sender].Start();
            ((System.Timers.Timer)sender).Stop();
        }

        private void PeriodicMessageTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (stream != null && messagesBetweenPeriodics >= Properties.Settings.Default.minimumMessagesBetweenPeriodic)
            {
                sendMessage(periodicMessageTimers[(System.Timers.Timer)sender]);
                messagesBetweenPeriodics = 0;
            }
        }



        public int runBot()
        {
            TcpClient client;
            try
            {
                int port = 6667;
                client = new TcpClient("irc.chat.twitch.tv", port);
                // Enter in channel (the username of the stream chat you wish to connect to) without the #

                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();

                stream = client.GetStream();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.StackTrace, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1;
            }

            streamReader = new StreamReader(stream, Encoding.UTF8);

            // Send the message to the connected TcpServer. 

            // string oauth = "5bdocznijbholgvt3o9u6t5ui6okjs";

            string loginstring = "PASS oauth:" + botOauth + "\r\nNICK " + botNick + "\r\n";
            string toShow = "PASS oauth:" + "*****" + "\r\nNICK " + botNick + "\r\n";
            sendToServer(loginstring);
            Console.WriteLine(toShow);
            mainForm.writeToServerOutputTextBox(toShow + "\r\n");

            // Receive the TcpServer.response.
            mainForm.writeToServerOutputTextBox(readFromServer() + "\r\n");

            // String to store the response ASCII representation.

            // Requesting tags capability for more info
            string tagReqString = "CAP REQ :twitch.tv/tags\r\n";
            sendToServer(tagReqString);

            // Read the request response
            readFromServer();

            // send message to join channel

            string joinstring = "JOIN " + "#" + channel + "\r\n";
            sendToServer(joinstring);

            mainForm.writeToServerOutputTextBox(readFromServer() + "\r\n");

            // PMs the channel to announce that it's joined and listening
            // These three lines are the example for how to send something to the channel

            string announcestring = channel + "!" + channel + "@" + channel + ".tmi.twitch.tv PRIVMSG " + channel + " BOT ENABLED\r\n";
            sendToServer(announcestring);

            helpCommands = "";
            for (int i = 0; i < validCommands.Count; i++)
            {
                if (displayCommandsInHelp[i])
                {
                    helpCommands += Properties.Settings.Default.prefix + validCommands[i] + ", ";
                }
            }
            helpCommands = helpCommands.Substring(0, helpCommands.Length - 2);

            willDisconnect = false;

            while (!willDisconnect)
            {
                ChatMessage msg = receiveMessage();
                msg.handleMessage();
            }

            addingQuote = false;
            quoteTimer.Stop();

            stream.Close();
            client.Close();
            return 0;
        }

        public void sendPong()
        {
            try
            {
                Byte[] say = System.Text.Encoding.UTF8.GetBytes("PONG :tmi.twitch.tv\r\n");
                stream.Write(say, 0, say.Length);
                //Console.WriteLine("Ping? Pong!");
                //mainForm.writeToServerOutputTextBox("Ping? Pong!");
            }
            catch (Exception e)
            {
                Console.WriteLine("OH SHIT SOMETHING WENT WRONG\r\n", e);
                mainForm.writeToServerOutputTextBox("OH SHIT SOMETHING WENT WRONG\r\n");
            }
        }

        public void printLinkTitles(string chatMessage)
        {
            Regex regx = new Regex(@"((http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?)", RegexOptions.IgnoreCase);
            MatchCollection mactches = regx.Matches(chatMessage);
            foreach (Match match in mactches)
            {
                WebClient x = new WebClient();
                string source;
                //WebRequest req = WebRequest.Create(match.Value);
                try
                {
                    x.Headers.Add("Accept-Language", " en-US");
                    x.Headers.Add("Accept", " text/html, application/xhtml+xml, */*");
                    x.Headers.Add("User-Agent", "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)");
                    source = HttpUtility.HtmlDecode(x.DownloadString(match.Value));
                }
                catch
                {
                    continue;
                }
                string title = Regex.Match(source, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;
                title = Regex.Replace(title, @"[^\u0000-\u007F]+", string.Empty);
                if (title != null && title != "")
                {
                    sendMessage(sender + " posted: " + title);
                }
            }
        }

        private ChatMessage receiveMessage()
        {
            string rawMessage = streamReader.ReadLine();
            Regex privmsgRegex = new Regex("");

            ChatMessage chatMessage;

            if (rawMessage.Equals("PING :tmi.twitch.tv"))
            {
                chatMessage = new ChatMessagePing(rawMessage);
            }
            else if (rawMessage.Contains("PRIVMSG"))
            {
                chatMessage = new ChatMessagePrivmsg(rawMessage);
            }
            else
            {
                chatMessage = new ChatMessage(rawMessage);
            }

            return chatMessage;
        }

        private void QuoteTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            sendMessage("Time's up. I guess no one thought that quote was funny.");
            quoteAdders.Clear();
            addingQuote = false;
            quoteTimer.Stop();
        }

        public void sendMessage(string message)
        {
            sendMessage(message, "");
        }

        public void sendMessage(string message, string commandArgs)
        {
            TimeSpan uptime = new TimeSpan(0);
            JObject broadcastData = null;
            foreach (String cmd in messageVars)
            {
                if (message.Contains("$" + cmd))
                {
                    switch (cmd)
                    {
                        case "QUOTE":
                            message = message.Replace("$QUOTE", getQuote());
                            break;
                        case "QNUM":
                            message = message.Replace("$QNUM", (lastQuote + 1).ToString());
                            break;
                        case "ADDQUOTE":
                            addQuote(commandArgs);
                            return;
                        case "VOTEYES":
                            voteYes();
                            return;
                        case "BROADCASTER":
                            message = message.Replace("$BROADCASTER", channel);
                            break;
                        case "SENDER":
                            message = message.Replace("$SENDER", sender);
                            break;
                        case "GAME":
                            if (broadcastData == null)
                            {
                                broadcastData = getBroadcastDataFromAPI();
                            }
                            message = message.Replace("$GAME", broadcastData.Property("game").Value.ToString());
                            break;
                        case "TITLE":
                            if (broadcastData == null)
                            {
                                broadcastData = getBroadcastDataFromAPI();
                            }
                            message = message.Replace("$TITLE", broadcastData.Property("status").Value.ToString());
                            break;
                        case "UPHOURS":
                            if (uptime.Ticks == 0)
                            {
                                uptime = getUptime();
                            }
                            message = message.Replace("$UPHOURS", uptime.Hours.ToString());
                            break;
                        case "UPMINUTES":
                            if (uptime.Ticks == 0)
                            {
                                uptime = getUptime();
                            }
                            message = message.Replace("$UPMINUTES", uptime.Minutes.ToString());
                            break;
                        case "8BALL":
                            message = message.Replace("$8BALL", get8BallResponse());
                            break;
                        case "CALCULATOR":
                            Expression e = new Expression(commandArgs);
                            string x = e.calculate().ToString();
                            message = message.Replace("$CALCULATOR", x);
                            break;
                        case "COMMANDS":
                            message = message.Replace("$COMMANDS", helpCommands);
                            break;

                    }
                }
            }


            Byte[] say = Encoding.UTF8.GetBytes("PRIVMSG #" + channel + " :" + message + "\r\n");
            stream.Write(say, 0, say.Length);
            mainForm.writeToServerOutputTextBox("<" + botNick + "> " + message + "\r\n");
        }

        private void calculateAndSendResponse(string message, string commandArgs)
        {
            Expression e = new Expression(commandArgs);
            string x = e.calculate().ToString();
            sendMessage(message.Replace("$CALCULATOR", x));
        }

        private void addQuote(string quote)
        {
            if (Properties.Settings.Default.quotes == null)
            {
                Properties.Settings.Default.quotes = new System.Collections.Specialized.StringCollection();
                Properties.Settings.Default.Save();
            }
            if (quotes == null)
            {
                string[] arrQuotes = new string[Properties.Settings.Default.quotes.Count];
                Properties.Settings.Default.quotes.CopyTo(arrQuotes, 0);
                quotes = new List<string>(arrQuotes);
                quoteTimer.Elapsed += QuoteTimer_Elapsed;
            }
            if (addingQuote)
            {
                sendMessage("Finish adding the current quote first.");
                return;
            }

            quoteToAdd = quote;

            if (Properties.Settings.Default.quoteAddingMethod == 0)
            {
                Properties.Settings.Default.quotes.Add(quoteToAdd);
                Properties.Settings.Default.Save();
                quotes.Add(quoteToAdd);
                sendMessage("Quote added.");
                return;
            }

            else if (Properties.Settings.Default.quoteAddingMethod == 1 || Properties.Settings.Default.quoteAddingMethod == 2)
            {
                if (sender == channel || (senderIsMod && Properties.Settings.Default.quoteAddingMethod == 1))
                {
                    Properties.Settings.Default.quotes.Add(quoteToAdd);
                    Properties.Settings.Default.Save();
                    quotes.Add(quoteToAdd);
                    sendMessage("Quote added.");
                    return;
                }
                else
                {
                    sendMessage("You don't have permission to do that.");
                    return;
                }
            }

            else if (Properties.Settings.Default.quoteAddingMethod == 3)
            {
                addingQuote = true;
                quoteTimer.Start();
                sendMessage((Properties.Settings.Default.quoteVotersNumber - 1).ToString() +
                             " other " + (Properties.Settings.Default.quoteVotersNumber > 2 ? "people need" : "person needs") + " to agree by typing " +
                             Properties.Settings.Default.prefix +
                             commandsTable.Select("Message LIKE '*$VOTEYES*'")[0].Field<string>("Command") +
                             " to add the quote! Ends in one minute.");
                quoteAdders.Add(sender);
            }

        }

        private void voteYes()
        {
            if (!addingQuote)
                return;

            if (!quoteAdders.Contains(sender))
            {
                quoteAdders.Add(sender);
                if (quoteAdders.Count == Properties.Settings.Default.quoteVotersNumber)
                {
                    wowiebot.Properties.Settings.Default.quotes.Add(quoteToAdd);
                    wowiebot.Properties.Settings.Default.Save();
                    quoteAdders.Clear();
                    quotes.Add(quoteToAdd);
                    addingQuote = false;
                    quoteTimer.Stop();
                    sendMessage("Quote added.");
                }
            }

            else if (quoteAdders[0] == sender)
            {
                sendMessage("Yeah, you added the quote. I got it.");
            }

            else
            {
                sendMessage("You already voted, dingus.");
            }

        }

        public string getBotNick()
        {
            return botNick;
        }

        public string getChannel()
        {
            return channel;
        }

        private List<String> getMods(string pChannel)
        {
            return null;
        }

        private String get8BallResponse()
        {
            if (Properties.Settings.Default.choices8Ball == null)
            {
                Properties.Settings.Default.choices8Ball = new System.Collections.Specialized.StringCollection();
                Properties.Settings.Default.Save();
            }
            if (eightBallChoices == null)
            {
                string[] arr8Ball = new string[Properties.Settings.Default.choices8Ball.Count];
                Properties.Settings.Default.choices8Ball.CopyTo(arr8Ball, 0);
                eightBallChoices = new List<string>(arr8Ball);
            }
            if (eightBallChoices.Count == 0)
            {
                return "You drop the 8-ball and it shatters irrecoverably onto the floor.";
            }
            int p;
            do
            {
                p = rnd.Next(eightBallChoices.Count);
            } while (p == lastChoice && eightBallChoices.Count > 1);
            lastChoice = p;
            return eightBallChoices[p];
        }
        
        private TimeSpan getUptime()
        {
            HttpWebRequest apiRequest = (HttpWebRequest)WebRequest.Create("https://api.twitch.tv/kraken/streams/" + userID);
            apiRequest.Accept = "application/vnd.twitchtv.v5+json";
            apiRequest.Headers.Add("Client-ID: jqqcl6f383moz9gzdd3aeg7lt4h0t0");


            Stream apiStream;

            apiStream = apiRequest.GetResponse().GetResponseStream();
            StreamReader apiReader = new StreamReader(apiStream);
            string jsonData = apiReader.ReadToEnd();
            JObject parsed = JObject.Parse(jsonData);
            JObject streamParsed = JObject.Parse(parsed.Property("stream").Value.ToString());

            apiReader.Close();
            apiReader.Dispose();

            apiStream.Close();
            apiStream.Dispose();

            if (parsed.Property("stream").Value.ToString() == "")
            {
                return new TimeSpan(-1);
            }
            string time = streamParsed.Property("created_at").ToString();
            DateTime liveTime = DateTime.Parse(streamParsed.Property("created_at").Value.ToString());
            //   DateTime liveTime = DateTime.ParseExact(streamParsed.Property("created_at").ToString(), "", new System.Globalization.CultureInfo("en-US"), System.Globalization.DateTimeStyles.None); 
            TimeSpan uptime = DateTime.Now.ToUniversalTime() - liveTime;

            return uptime;

            sendMessage(channel + " has been live for " + uptime.Hours + " hours and " + uptime.Minutes + " minutes.");

        }

        private String getQuote()
        {
            if (Properties.Settings.Default.quotes == null)
            {
                Properties.Settings.Default.quotes = new System.Collections.Specialized.StringCollection();
                Properties.Settings.Default.Save();
            }
            if (quotes == null)
            {
                string[] arrQuotes = new string[Properties.Settings.Default.quotes.Count];
                Properties.Settings.Default.quotes.CopyTo(arrQuotes, 0);
                quotes = new List<string>(arrQuotes);
                quoteTimer.Elapsed += QuoteTimer_Elapsed;
            }
            if (quotes.Count == 0)
            {
                return "No quotes. I guess " + channel + " just isn't funny or quotable.";
            }
            int q;
            do
            {
                q = rnd.Next(quotes.Count);
            } while (q == lastQuote && quotes.Count > 1);
            lastQuote = q;
            return quotes[q];
        }

        private JObject getBroadcastDataFromAPI()
        {
            HttpWebRequest apiRequest = (HttpWebRequest)WebRequest.Create("https://api.twitch.tv/kraken/channels/" + userID);
            apiRequest.Accept = "application/vnd.twitchtv.v5+json";
            apiRequest.Headers.Add("Client-ID: jqqcl6f383moz9gzdd3aeg7lt4h0t0");

            Stream apiStream;

            apiStream = apiRequest.GetResponse().GetResponseStream();
            StreamReader apiReader = new StreamReader(apiStream);
            string jsonData = apiReader.ReadToEnd();

            JObject parsed = JObject.Parse(jsonData);

            apiReader.Close();
            apiReader.Dispose();

            apiStream.Close();
            apiStream.Dispose();

            return parsed;

            sendMessage(channel + " is streaming " + parsed.Property("game").Value.ToString() + ": \"" + parsed.Property("status").Value.ToString() + "\"");
        }

        private String getQuote(int i)
        {
            if (Properties.Settings.Default.quotes == null)
            {
                Properties.Settings.Default.quotes = new System.Collections.Specialized.StringCollection();
                Properties.Settings.Default.Save();
            }
            if (quotes == null)
            {
                string[] arrQuotes = new string[Properties.Settings.Default.quotes.Count];
                Properties.Settings.Default.quotes.CopyTo(arrQuotes, 0);
                quotes = new List<string>(arrQuotes);
                quoteTimer.Elapsed += QuoteTimer_Elapsed;
            }
            if (quotes.Count > i)
            {
                return quotes[i];
            }
            else
            {
                return "Index out of range.";
            }
        }

        private void getUserIDFromAPI()
        {
            HttpWebRequest apiRequest = (HttpWebRequest)WebRequest.Create("https://api.twitch.tv/kraken/users?login=" + channel);
            apiRequest.Accept = "application/vnd.twitchtv.v5+json";
            apiRequest.Headers.Add("Client-ID: jqqcl6f383moz9gzdd3aeg7lt4h0t0");

            Stream apiStream;

            apiStream = apiRequest.GetResponse().GetResponseStream();
            StreamReader apiReader = new StreamReader(apiStream);
            string jsonData = apiReader.ReadToEnd();

            JObject parsed = JObject.Parse(jsonData);
            JObject userParsed = JObject.Parse(parsed.GetValue("users").First.ToString());

            apiReader.Close();
            apiReader.Dispose();

            apiStream.Close();
            apiStream.Dispose();

            userID = userParsed.GetValue("_id").ToString();
        }

        public void disconnect()
        {
            willDisconnect = true;
            foreach (KeyValuePair<System.Timers.Timer, System.Timers.Timer> timer in offsetTimers)
            {
                timer.Key.Enabled = false;
                timer.Value.Enabled = false;
            }
            offsetTimers.Clear();
            foreach (KeyValuePair<System.Timers.Timer,string> timer in periodicMessageTimers)
            {
                timer.Key.Enabled = false;
            }
            periodicMessageTimers.Clear();
        }

        private void populateValidCommands()
        {

            DataRow[] commands = commandsTable.Select("enabled = true");
            foreach (DataRow i in commands)
            {
                validCommands.Add(i.Field<string>("Command"));
                displayCommandsInHelp.Add(i.Field<bool>("Show in commands list"));
            }

            return;
        }

        private void sendToServer(string strToSend)
        {
            Byte[] bytesToSend = System.Text.Encoding.UTF8.GetBytes(strToSend);
            stream.Write(bytesToSend, 0, bytesToSend.Length);
        }

        private string readFromServer()
        {
            String responseData = String.Empty;

            // Read the first batch of the TcpServer response bytes.
            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.UTF8.GetString(data, 0, bytes);
            return responseData;
        }
    }
}
