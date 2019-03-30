namespace wowiebot
{
    class ChatMessagePing : ChatMessage
    {
        public ChatMessagePing(string rawMessage) : base(rawMessage) { }

        public override void handleMessage()
        {
            ChatHandler.sendPong();
        }
    }
}
