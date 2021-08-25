using HW11_01.Enums;
using System;

namespace HW11_01.Models
{
    class Interactions
    {
        public static Genre GenreInput(string genre)
        {
            Genre SongGenre;
            try
            {
                SongGenre = (Genre)Enum.Parse(typeof(Genre), genre);
            }
            catch (Exception)
            {
                SongGenre = default;
            }
            return SongGenre;
        }

        public static object GetSongData(Song track)
        {
            var song = new
            {
                Title = track.SongName,
                Minutes = track.SongLenght,
                AlbumYear = track.SongDate
            };
            return song;
        }

        public static int IntValid()
        {
            int a;
            while (int.TryParse(ReadData(),out a))
            {
                Console.WriteLine("Incorrect data input");
            }
            return a;
        }

        public static string ReadData()
        {
            string data;
            while (string.IsNullOrWhiteSpace(data = Console.ReadLine()))
            {
                Console.WriteLine("No data has been entered");
            }
            return data;
        }
    }
}
