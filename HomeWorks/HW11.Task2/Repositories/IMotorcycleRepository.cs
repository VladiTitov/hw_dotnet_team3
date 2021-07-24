using System.Collections.Generic;
using HW11.Task2.Models;

namespace HW11.Task2.Repositories
{
    public interface IMotorcycleRepository
    {
        public Motorcycle GetMotorcycleByID(int id);
        public IEnumerable<Motorcycle> GetMotorcycles();
        public void CreateMotorcycle(Motorcycle item);
        public void UpdateMotorcycle(Motorcycle item);
        public void DeleteMotorcycle(Motorcycle item);
    }
}
