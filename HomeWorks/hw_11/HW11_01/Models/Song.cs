using HW11_01.Enums;
using System;

namespace HW11_01.Models
{
    class Song
    {
        public string SongName;
        public int SongLenght;
        public string SongAuthor;
        public int SongDate;
        public Genre SongGenre
        {
            get { return SongGenre; }
            set
            {
                if (Enum.IsDefined(typeof(Genre), value))
                {
                    SongGenre = value;
                }
                else
                {
                    SongGenre = default;
                }
            }
        }

        public Song(string name, int lenght, string author, int date, Genre genre)
        {
            SongName = name;
            SongLenght = lenght;
            SongAuthor = author;
            SongDate = date;
            SongGenre = genre;
        }
    }
}
