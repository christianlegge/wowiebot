using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using wowiebot;

namespace wowiebotTest
{
    [TestClass]
    public class WowiebotTests
    {
        [TestMethod]
        public void TestChatMessagePrivmsgConstructor()
        {
            string msg = "@badges=broadcaster/1,subscriber/0,premium/1;color=#FF7F50;display-name=scatter;emotes=25:0-4/268639:11-20;id=da6d4120-8e8f-4d07-90a3-100c8e6d2d81;mod=0;room-id=45904825;subscriber=1;tmi-sent-ts=1522690647094;turbo=0;user-id=45904825;user-type= :scatter!scatter@scatter.tmi.twitch.tv PRIVMSG #scatter :Kappa test scatteBust";
            ChatMessagePrivmsg chatMessage = new ChatMessagePrivmsg(msg);
            Assert.AreEqual("scatter", chatMessage.getSender(), "Incorrect sender");
            Assert.AreEqual("Kappa test scatteBust", chatMessage.getMessage(), "Incorrect message");
        }

        [TestMethod]
        public void TestGetYoutubeID()
        {
            SongRequest sr = new SongRequest("https://www.youtube.com/watch?v=7lEOJUnJyk8&t=46s");
            String expected = "7lEOJUnJyk8";
            String actual = sr.getYoutubeID();
            Assert.AreEqual(expected, actual, "Incorrect Youtube ID Returned");
        }
    }
}
