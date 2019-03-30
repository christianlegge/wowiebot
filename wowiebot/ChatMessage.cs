namespace wowiebot
{
    public class ChatMessage
    {
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
    }
}
