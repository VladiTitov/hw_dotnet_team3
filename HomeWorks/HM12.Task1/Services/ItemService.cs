using System;
using System.Collections.Generic;
using System.Linq;
using HM12.Task1.Models;
using HM12.Task1.Services.ModelsServices.Classes;
using HM12.Task1.Services.ModelsServices.Interfaces;

namespace HM12.Task1.Services
{
    public class ItemService
    {
        private readonly IMotorcycleService _motorcycleService;

        public ItemService(ApplicationContext db)
        {
            _motorcycleService = new MotorcycleService(db);
        }

        public void ItemEvent()
        {
            switch (GetOperationKey())
            {
                case "C":
                    _motorcycleService.CreateItem(GetMotorcycle());
                    break;
                case "R":
                    _motorcycleService.ShowItems();
                    break;
                case "U":
                    Console.WriteLine("On development stage");
                    break;
                case "D":
                    _motorcycleService.DeleteItem(GetDeleteMotorcycle(_motorcycleService.GetItems()));
                    break;
            }
        }

        private string GetOperationKey()
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

        private Motorcycle GetDeleteMotorcycle(IEnumerable<Motorcycle> data)
        {
            ShowAllMotorcycles(data);
            int id = GetIntValue("Enter ID motorcycle to delete");
            while (!data.Select(i => i.ID).Contains(id))
            {
                Console.WriteLine("Non-existent ID entered");
                id = GetIntValue("Enter ID motorcycle to delete");
            }
            return data.FirstOrDefault(i => i.ID.Equals(id));
        }

        private void ShowAllMotorcycles(IEnumerable<Motorcycle> data)
        {
            Console.WriteLine(new string('-', 35));
            foreach (var motorcycle in data)
            {
                Console.WriteLine(motorcycle);
            }
            Console.WriteLine(new string('-', 35));
        }

        private Motorcycle GetMotorcycle() => new Motorcycle()
        {
            Name = InputOutput("Enter motocycle name:"),
            Model = InputOutput("Enter motocycle model:"),
            Year = GetIntValue("Enter motocycle year:")
        };

        private string InputOutput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine().ToUpper();
        }

        private int GetIntValue(string message)
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
