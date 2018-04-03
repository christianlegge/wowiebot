using System;

namespace wowiebot
{
    class Quote
    {
        private string quoteText;
        private int quoteNumber;
        private DateTime quoteAddedDate;

        public Quote(string q, int qnum)
        {
            quoteText = q;
            quoteNumber = qnum;
        }

        public string getQuoteText()
        {
            return quoteText;
        }

        public int getQuoteNumber()
        {
            return quoteNumber;
        }
    }
}
