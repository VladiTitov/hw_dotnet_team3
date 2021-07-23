using HW11.Task2.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HW11.Task2.Repositories
{
    class MotorcycleRepository : IMotorcycleRepository
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Motorcycle> _dbSet;

        public MotorcycleRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<Motorcycle>();
        }

        public void CreateMotorcycle(Motorcycle item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public void DeleteMotorcycle(Motorcycle item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

        public Motorcycle GetMotorcycleByID(int id) => GetMotorcycles().FirstOrDefault(i => i.ID.Equals(id));

        public IEnumerable<Motorcycle> GetMotorcycles() => _dbSet.AsNoTracking().ToList();

        public void UpdateMotorcycle(Motorcycle item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
