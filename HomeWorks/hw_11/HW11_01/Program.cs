using HW11_01.Models;

namespace HW11_01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Input song name");
            //string name = Interactions.ReadData();
            //Console.WriteLine("Input song lenght");
            //int lenght = Interactions.IntValid();
            //Console.WriteLine("Input song author");
            //string songAuthor = Interactions.ReadData();
            //Console.WriteLine("Input song year");
            //int year = Interactions.IntValid();
            //Console.WriteLine("Input song genre");
            //Genre genre = Interactions.GenreInput(Interactions.ReadData());

            Song song = new("Requiem", 60, "Mozart", 1800, Interactions.GenreInput("1"));
            var track = Interactions.GetSongData(song);

            JsonServices test = new();
            test.NewtosoftService(track);
            test.SystemTextService(track);
        }
    }
}
