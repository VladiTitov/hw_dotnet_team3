using System;
using System.Collections.Generic;
using System.Linq;
using HM12.Task1.Models;
using HM12.Task1.Repositories;
using HM12.Task1.Services.ModelsServices.Interfaces;

namespace HM12.Task1.Services.ModelsServices.Classes
{
    class MotorcycleService : IMotorcycleService
    {
        private readonly IGenericRepository<Motorcycle> _genericRepository;

        public MotorcycleService(ApplicationContext context) => _genericRepository = new GenericRepository<Motorcycle>(context);

        public void CreateItem() => _genericRepository.CreateItem(GetMotorcycle());
        public void DeleteItem() => _genericRepository.DeleteItem(GetItemById(GetValidId()));
        private int GetValidId()
        {
            ShowItems();

            int id = Program.GetIntValue("Enter ID motorcycle to delete");
            while (!GetItems().Select(i => i.ID).Contains(id))
            {
                Console.WriteLine("Non-existent ID entered");
                id = Program.GetIntValue("Enter ID motorcycle to delete");
            }
            return id;
        }
        public Motorcycle GetItemById(int id) => _genericRepository.GetItemByID(motorcycle => motorcycle.ID.Equals(id));
        public void ShowItems()
        {
            Console.WriteLine(new string('-', 35));
            foreach (var motorcycle in GetItems())
            {
                Console.WriteLine(motorcycle);
            }
            Console.WriteLine(new string('-', 35));
        }
        private Motorcycle GetMotorcycle() => new Motorcycle()
        {
            Name = Program.InputOutput("Enter motocycle name:"),
            Model = Program.InputOutput("Enter motocycle model:"),
            Year = Program.GetIntValue("Enter motocycle year:")
        };
        public IEnumerable<Motorcycle> GetItems() => _genericRepository.GetItems();
        public void UpdateItem(Motorcycle item) => _genericRepository.UpdateItem(item);
    }
}
