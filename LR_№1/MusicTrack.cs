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
        public string Year { get; set; } // Замена типа данных поля Year с int на string
        bool err = false;
        public MusicTrack(string artist, string title, string genre, string year)
        {
            /*
            Выбрасываем исключения при неправильном вводе со следующими тестами:
            1. Проверка на пустое значение исполнителя.
            2. Проверка на пустое значение названия.
            3. Проверка на пустое значение жанра.
            4. Проверка на пустое значение года.
            5. Проверка на некорректный формат года (что-то кроме чисел).
            6. Проверка на некорректное значение даты (<0 || >нынешнего).
            */
            if (string.IsNullOrWhiteSpace(artist))
                throw new ArgumentException("Исполнитель не может быть пустым", nameof(artist));

            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Название не может быть пустым", nameof(title));

            if (string.IsNullOrWhiteSpace(genre))
                throw new ArgumentException("Жанр не может быть пустым", nameof(genre));

            if (string.IsNullOrWhiteSpace(year.ToString()))
                throw new ArgumentException("Жанр не может быть пустым", nameof(year));

            if (!int.TryParse(year, out int result))
                throw new ArgumentException($"Неверный формат даты!", nameof(year));

            if (int.Parse(year) < 0 || int.Parse(year) > DateTime.Now.Year)
                throw new ArgumentException($"Год должен быть от 1 до {DateTime.Now.Year}", nameof(year));

            Artist = artist;
            Title = title;
            Genre = genre;
            Year = year;
        }

        public override bool Equals(object obj)
        {
            if (obj is MusicTrack other)
            {
                return Artist == other.Artist &&
                       Title == other.Title &&
                       Genre == other.Genre &&
                       Year == other.Year;
            }
            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (Artist?.GetHashCode() ?? 0);
                hash = hash * 23 + (Title?.GetHashCode() ?? 0);
                hash = hash * 23 + (Genre?.GetHashCode() ?? 0);
                hash = hash * 23 + (Year?.GetHashCode() ?? 0);
                return hash;
            }
        }

        public override string ToString()
        {
            return $"{Artist} - {Title} ({Year}) [{Genre}]";
        }
    }
}
