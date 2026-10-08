using LR__2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace UnitTest
{
    [TestClass]
    public class UnitTestMusicCollection
    {
        [TestMethod]
        public void DeleteButton_Click_Test()
        {
            var listView = new ListView();
            var collection = new MusicCollection(listView);

            var track = new MusicTrack("Metallica", "Enter Sandman", "Metal", "1991");
            collection.AddTrack(track);

            Assert.AreEqual(1, listView.Items.Count);
            collection.RemoveTrack(track);

            Assert.AreEqual(0, listView.Items.Count, "Трек должен быть удален");
        }

        [TestMethod]
        public void SortButton_Click_Test()
        {
            var listView = new ListView();
            var collection = new MusicCollection(listView);

            var track = new MusicTrack("Metallica", "Enter Sandman", "Metal", "1993");
            var track1 = new MusicTrack("Кипелов", "Вавилон", "Хеви-метал", "2004");
            var track2 = new MusicTrack("The Offspring", "You're Gonna Go Far, Kid", "Панк-рок", "2008");
            var track3 = new MusicTrack("Scorpions ", "No on like you", "Хеви-метал", "1982");
            var track4 = new MusicTrack("Король и Шут", "Утренний рассвет", "Фолк-панк", "1999");
            collection.AddTrack(track);
            collection.AddTrack(track1);
            collection.AddTrack(track2);
            collection.AddTrack(track3);
            collection.AddTrack(track4);

            collection.SortByYear();

            Assert.AreEqual("1982", listView.Items[0].SubItems[3].Text, "Первое место");
            Assert.AreEqual("1993", listView.Items[1].SubItems[3].Text, "Второе место");
            Assert.AreEqual("1999", listView.Items[2].SubItems[3].Text, "Третье место");
            Assert.AreEqual("2004", listView.Items[3].SubItems[3].Text, "Четвёртое место");
            Assert.AreEqual("2008", listView.Items[4].SubItems[3].Text, "Пяиое место");
        }

        [TestMethod]
        public void SearchButton_Click_Test()
        {
            var listView = new ListView();
            var collection = new MusicCollection(listView);

            var track = new MusicTrack("Metallica", "Enter Sandman", "Metal", "1993");
            var track1 = new MusicTrack("Кипелов", "Вавилон", "Хеви-метал", "2004");
            var track2 = new MusicTrack("The Offspring", "You're Gonna Go Far, Kid", "Панк-рок", "2008");
            var track3 = new MusicTrack("Scorpions ", "No on like you", "Хеви-метал", "1982");
            var track4 = new MusicTrack("Король и Шут", "Утренний рассвет", "Фолк-панк", "1999");
            collection.AddTrack(track);
            collection.AddTrack(track1);
            collection.AddTrack(track2);
            collection.AddTrack(track3);
            collection.AddTrack(track4);

            collection.SearchByArtist("Кипелов");

            Assert.AreEqual("Кипелов", listView.Items[0].SubItems[0].Text, "Поиск выполнен");
        }
    }
}
