using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wowiebot
{
    class WowiebotSettings
    {
        public string id;
        public string prevChannel;
        public string[] quotes;
        public string prefix;
        public bool enableLinkTitles;
        public string[] choices8Ball;
        public string commandsDataTableJson;
        public int quoteAddingMethod;
        public int quoteVotersNumber;
        public string emptyQuotesMessage;
        public string periodicMessagesDataTableJson;
        public string noPermsMessage;
        public int minimumMessagesBetweenPeriodic;

        public WowiebotSettings()
        {
            
        }

        public void loadFromSettings()
        {
            prevChannel = Properties.Settings.Default.prevChannel;
            quotes = Properties.Settings.Default.quotes.Cast<string>().ToArray();
            prefix = Properties.Settings.Default.prefix;
            enableLinkTitles = Properties.Settings.Default.enableLinkTitles;
            choices8Ball = Properties.Settings.Default.choices8Ball.Cast<string>().ToArray();
            commandsDataTableJson = Properties.Settings.Default.commandsDataTableJson;
            quoteAddingMethod = Properties.Settings.Default.quoteAddingMethod;
            quoteVotersNumber = Properties.Settings.Default.quoteVotersNumber;
            emptyQuotesMessage = Properties.Settings.Default.emptyQuotesMessage;
            periodicMessagesDataTableJson = Properties.Settings.Default.periodicMessagesDataTableJson;
            minimumMessagesBetweenPeriodic = Properties.Settings.Default.minimumMessagesBetweenPeriodic;
            noPermsMessage = Properties.Settings.Default.noPermsMessage;
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
            Properties.Settings.Default.enableLinkTitles = enableLinkTitles;
            if (choices8Ball != null)
            {
                Properties.Settings.Default.choices8Ball = new StringCollection();
                Properties.Settings.Default.choices8Ball.AddRange(choices8Ball);
            }
            if (commandsDataTableJson != null)
            {
                Properties.Settings.Default.commandsDataTableJson = commandsDataTableJson;
            }
            Properties.Settings.Default.quoteAddingMethod = quoteAddingMethod;
            Properties.Settings.Default.quoteVotersNumber = quoteVotersNumber;
            if (emptyQuotesMessage != null)
            {
                Properties.Settings.Default.emptyQuotesMessage = emptyQuotesMessage;
            }
            if (periodicMessagesDataTableJson != null)
            {
                Properties.Settings.Default.periodicMessagesDataTableJson = periodicMessagesDataTableJson;
            }
            Properties.Settings.Default.minimumMessagesBetweenPeriodic = minimumMessagesBetweenPeriodic;
            Properties.Settings.Default.noPermsMessage = noPermsMessage;
            Properties.Settings.Default.Save();
        }
    }
}
