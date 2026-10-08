using LR__2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace UnitTest
{
    [TestClass]
    public class UnitTestMusicTrack
    {
        [TestMethod]
        public void AddTest()
        {
            var track = new MusicTrack("Singer", "Song", "Style", "5");
            var result = track.ToString();

            StringAssert.Contains(result, "Singer");
            StringAssert.Contains(result, "Song");
            StringAssert.Contains(result, "Style");
            StringAssert.Contains(result, "5");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddTestNull()
        {
            new MusicTrack("Singer", "Song", null, "5");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddTestOtrDate()
        {
            new MusicTrack("Singer", "Song", "Style", "-5");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddTestBolDate()
        {
            new MusicTrack("Singer", "Song", "Style", "2060");
        }

        [TestMethod]
        public void AddTestZeroDate()
        {
            var track = new MusicTrack("Singer", "Song", "Style", "0");
            var result = track.ToString();

            StringAssert.Contains(result, "Singer");
            StringAssert.Contains(result, "Song");
            StringAssert.Contains(result, "Style");
            StringAssert.Contains(result, "0");
        }

        [TestMethod]
        public void AddTestNowDate()
        {
            var track = new MusicTrack("Singer", "Song", "Style", $"{DateTime.Now.Year}");
            var result = track.ToString();

            StringAssert.Contains(result, "Singer");
            StringAssert.Contains(result, "Song");
            StringAssert.Contains(result, "Style");
            StringAssert.Contains(result, $"{DateTime.Now.Year}");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddTestStringDate()
        {
            new MusicTrack("Singer", "Song", "Style", "ьсцльлсц");
        }
    }
}
