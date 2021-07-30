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

        public void CreateItem(Motorcycle item) => _genericRepository.CreateItem(item);

        public void DeleteItem(Motorcycle item) => _genericRepository.DeleteItem(item);

        public Motorcycle GetItemById(Motorcycle item) => _genericRepository.GetItemByID(motorcycle => motorcycle.ID.Equals(item.ID));
        public void ShowItems()
        {
            Console.WriteLine(new string('-', 35));
            foreach (var motorcycle in GetItems())
            {
                Console.WriteLine(motorcycle);
            }
            Console.WriteLine(new string('-', 35));
        }

        public IEnumerable<Motorcycle> GetItems() => _genericRepository.GetItems();

        public void UpdateItem(Motorcycle item) => _genericRepository.UpdateItem(item);
    }
}
