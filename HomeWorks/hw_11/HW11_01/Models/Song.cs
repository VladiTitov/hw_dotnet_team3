using HW11_01.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11_01.Models
{
    class Song
    {
        string _songName;
        public string SongName
        {
            get { return _songName; }
            set { _songName = value; }
        }
        int _songLenght;
        public int SongLenght
        {
            get { return _songLenght; }
            set { _songLenght = value; }
        }
        string _songAuthor;
        public string SongAuthor
        {
            get { return _songAuthor; }
            set { _songAuthor = value; }
        }
        int _songDate;
        public int SongDate
        {
            get { return _songDate; }
            set { _songDate = value; }
        }
        Genre _songGenre;
        public Genre SongGenre
        {
            get { return _songGenre; }
            set
            {
                if (Enum.IsDefined(typeof(Genre), value))
                {
                    _songGenre = value;
                }
                else
                {
                    _songGenre = default;
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
