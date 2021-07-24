using HW11_01.Enums;
using HW11_01.Models;
using Newtonsoft.Json;
using System.Text.Json;
using System;
using System.Diagnostics;
using System.IO;

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

            string name = "Requiem";
            int lenght = 60;
            string songAuthor = "Mozart";
            int year = 1800;
            Genre genre = Interactions.GenreInput("1");
            
            Song song = new(name, lenght, songAuthor, year, genre);
            var track = Interactions.GetSongData(song);

            Stopwatch newtonsoft = new();
            newtonsoft.Start();
            string newtonsoftResult = Newtonsoft.Json.JsonConvert.SerializeObject(track);
            newtonsoft.Stop();
            Console.WriteLine(newtonsoftResult);
            string jsonFile = "jsonFileSong.json"; 
            File.WriteAllText(jsonFile, newtonsoftResult);

            Stopwatch systemText = new();
            systemText.Start();
            string systemTextResult = System.Text.Json.JsonSerializer.Serialize(track);
            systemText.Stop();
            Console.WriteLine(systemTextResult);

            Console.WriteLine("Newtonsoft.Json: {0} ms", newtonsoft.ElapsedMilliseconds);
            Console.WriteLine("System.Text.Json: {0} ms", systemText.ElapsedMilliseconds);
        }
    }
}
