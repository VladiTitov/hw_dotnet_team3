using HW11_01.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            bool valid = int.TryParse(ReadData(), out int a);
            while (!valid)
            {
                Console.WriteLine("Incorrect data input");
                valid = int.TryParse(ReadData(), out a);
            }
            return a;
        }

        public static string ReadData()
        {
            string data = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(data))
            {
                Console.WriteLine("No data has been entered");
                data = Console.ReadLine();
            }
            return data;
        }
    }
}
