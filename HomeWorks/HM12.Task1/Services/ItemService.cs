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
                    _motorcycleService.CreateItem();
                    break;
                case "R":
                    _motorcycleService.ShowItems();
                    break;
                case "U":
                    Console.WriteLine("On development stage");
                    break;
                case "D":
                    _motorcycleService.DeleteItem();
                    break;
            }
        }

        private string GetOperationKey()
        {
            string[] keys = new[] { "C", "R", "U", "D" };
            string message = "Operations available:\n[C] - Create new motorcycle\n[R] - View all motorcycles from data base\n[U] - Update motorcycle (on development stage)\n[D] - Delete motorcycle";

            var key = Program.InputOutput(message);
            while (!keys.Contains(key))
            {
                Console.WriteLine("Enter one of the suggested options!");
                LoggingService.AddEventToLog("Invalid key entered for action on DB");
                key = Program.InputOutput(message);
            }
            return key;
        }
    }
}
