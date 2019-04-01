using System;
using System.Collections.Specialized;
using System.Linq;

namespace wowiebot
{
    class WowiebotSettings
    {
        public string id;
        public string prevChannel;
        public string[] quotes;
        public string prefix;
        public string[] choices8Ball;
        public string[] periodicMessageArray;
        public string commandsDataTableJson;
        public int quoteVotersNumber;
        public string emptyQuotesMessage;
        public string noPermsMessage;
        public int minimumMessagesBetweenPeriodic;
        public string messageForBits;
        public int bitsMessageThreshold;
        public int periodicMessagePeriod;
        public string linkResponse;
        public string empty8BallResponse;
        public string subResponse;
        public string giftSubResponse;
        public string raidResponse;
        public string closedSrWindowResponse;
        public string nonEmbeddableSrResponse;
        public string quoteTimerElapsedResponse;


        public WowiebotSettings()
        {
            
        }

        public void loadFromSettings()
        {
            prevChannel = Properties.Settings.Default.prevChannel;
            quotes = Properties.Settings.Default.quotes.Cast<string>().ToArray();
            prefix = Properties.Settings.Default.prefix;
            choices8Ball = Properties.Settings.Default.choices8Ball.Cast<string>().ToArray();
            periodicMessageArray = Properties.Settings.Default.periodicMessagesArray.Cast<string>().ToArray();
            commandsDataTableJson = Properties.Settings.Default.commandsDataTableJson;
            quoteVotersNumber = Properties.Settings.Default.quoteVotersNumber;
            emptyQuotesMessage = Properties.Settings.Default.emptyQuotesMessage;
            minimumMessagesBetweenPeriodic = Properties.Settings.Default.minimumMessagesBetweenPeriodic;
            noPermsMessage = Properties.Settings.Default.noPermsMessage;
            messageForBits = Properties.Settings.Default.messageForBits;
            bitsMessageThreshold = Properties.Settings.Default.bitsMessageThreshold;
            periodicMessagePeriod = Properties.Settings.Default.periodicMessagePeriod;
            linkResponse = Properties.Settings.Default.linkResponse;
            empty8BallResponse = Properties.Settings.Default.empty8BallResponse;
            subResponse = Properties.Settings.Default.subResponse;
            giftSubResponse = Properties.Settings.Default.giftSubResponse;
            raidResponse = Properties.Settings.Default.raidResponse;
            closedSrWindowResponse = Properties.Settings.Default.closedSrWindowResponse;
            nonEmbeddableSrResponse = Properties.Settings.Default.nonEmbeddableSrResponse;
            quoteTimerElapsedResponse = Properties.Settings.Default.quoteTimerElapsedResponse;
        }

        public void saveToSettings()
        {
            if (!"YesImWowiebotSettings".Equals(id))
            {
                throw new Exception();
            }

            if (prevChannel != null)
            {
                Properties.Settings.Default.prevChannel = prevChannel;
            }
            if (quotes != null)
            {
                Properties.Settings.Default.quotes = new StringCollection();
                Properties.Settings.Default.quotes.AddRange(quotes);
            }
            if (prefix != null)
            {
                Properties.Settings.Default.prefix = prefix;
            }
            if (choices8Ball != null)
            {
                Properties.Settings.Default.choices8Ball = new StringCollection();
                Properties.Settings.Default.choices8Ball.AddRange(choices8Ball);
            }
            if (periodicMessageArray != null)
            {
                Properties.Settings.Default.periodicMessagesArray = new StringCollection();
                Properties.Settings.Default.periodicMessagesArray.AddRange(periodicMessageArray);
            }
            if (commandsDataTableJson != null)
            {
                Properties.Settings.Default.commandsDataTableJson = commandsDataTableJson;
            }
            Properties.Settings.Default.quoteVotersNumber = quoteVotersNumber;
            if (emptyQuotesMessage != null)
            {
                Properties.Settings.Default.emptyQuotesMessage = emptyQuotesMessage;
            }
            Properties.Settings.Default.minimumMessagesBetweenPeriodic = minimumMessagesBetweenPeriodic;
            Properties.Settings.Default.noPermsMessage = noPermsMessage;
            Properties.Settings.Default.bitsMessageThreshold = bitsMessageThreshold;
            Properties.Settings.Default.messageForBits = messageForBits;
            Properties.Settings.Default.periodicMessagePeriod = periodicMessagePeriod;
            Properties.Settings.Default.linkResponse = linkResponse;
            Properties.Settings.Default.empty8BallResponse = empty8BallResponse;
            Properties.Settings.Default.subResponse = subResponse;
            Properties.Settings.Default.giftSubResponse = giftSubResponse;
            Properties.Settings.Default.raidResponse = raidResponse;
            Properties.Settings.Default.closedSrWindowResponse = closedSrWindowResponse;
            Properties.Settings.Default.nonEmbeddableSrResponse = nonEmbeddableSrResponse;
            Properties.Settings.Default.quoteTimerElapsedResponse = quoteTimerElapsedResponse;
            Properties.Settings.Default.Save();
        }
    }
}
