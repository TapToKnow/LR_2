using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LR__2
{
    public class MusicTrack
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public MusicTrack(string artist, string title, string genre, int year)
        {
            Artist = artist;
            Title = title;
            Genre = genre;
            Year = year;
        }
        public override string ToString()
        {
            return $"{Artist} - {Title} ({Year}) [{Genre}]";
        }
    }
}
