using System;
using System.Collections.Generic;
using System.Linq;
using HW11.Task2.Models;
using HW11.Task2.Repositories;

namespace HW11.Task2.Services
{
    public class MotorcycleService
    {
        public static void MotorcycleEvents(IMotorcycleRepository repository)
        {
            switch (GetOperationKey())
            {
                case "C":
                    repository.CreateMotorcycle(GetMotorcycle());
                    break;
                case "R":
                    ShowAllMotorcycles(repository.GetMotorcycles());
                    break;
                case "U":
                    Console.WriteLine("On development stage");
                    break;
                case "D":
                    repository.DeleteMotorcycle(GetDeleteMotorcycle(repository.GetMotorcycles()));
                    break;
            }
        }

        private static string GetOperationKey()
        {
            string[] keys = new[] { "C", "R", "U", "D" };
            string message = "Operations available:\n[C] - Create new motorcycle\n[R] - View all motorcycles from data base\n[U] - Update motorcycle (on development stage)\n[D] - Delete motorcycle";

            var key = InputOutput(message);
            while (!keys.Contains(key))
            {
                Console.WriteLine("Enter one of the suggested options!");
                LoggingService.AddEventToLog("Invalid key entered for action on DB");
                key = InputOutput(message);
            }
            return key;
        }

        private static Motorcycle GetDeleteMotorcycle(IEnumerable<Motorcycle> data)
        {
            ShowAllMotorcycles(data);
            int id = GetIntValue("Enter ID motorcycle to delete");
            while (!data.Select(i=>i.ID).Contains(id))
            {
                Console.WriteLine("Non-existent ID entered");
                id = GetIntValue("Enter ID motorcycle to delete");
            }
            return data.FirstOrDefault(i => i.ID.Equals(id));
        }

        private static void ShowAllMotorcycles(IEnumerable<Motorcycle> data)
        {
            Console.WriteLine(new string('-', 35));
            foreach (var motorcycle in data)
            {
                Console.WriteLine(motorcycle);
            }
            Console.WriteLine(new string('-', 35));
        }

        private static Motorcycle GetMotorcycle() => new Motorcycle()
        {
            Name = InputOutput("Enter motocycle name:"),
            Model = InputOutput("Enter motocycle model:"),
            Year = GetIntValue("Enter motocycle year:")
        };

        private static string InputOutput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine().ToUpper();
        }

        private static int GetIntValue(string message)
        {
            int result;
            while (!Int32.TryParse(InputOutput(message), out result))
            {
                Console.WriteLine("Enter valid value!");
            }

            return result;
        }
    }
}
