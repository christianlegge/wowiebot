using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using wowiebot;

namespace wowiebotTest
{
    [TestClass]
    public class WowiebotTests
    {
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
