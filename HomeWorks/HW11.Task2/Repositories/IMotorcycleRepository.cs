using System.Collections.Generic;
using HW11.Task2.Models;

namespace HW11.Task2.Repositories
{
    interface IMotorcycleRepository
    {
        public Motorcycle GetMotorcycleByID(string id);
        public IEnumerable<Motorcycle> GetMotorcycles();
        public void CreateMotorcycle();
        public void UpdateMotorcycle();
        public void DeleteMotorcycle();
    }
}
