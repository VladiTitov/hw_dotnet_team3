using HW11.Task2.Models;
using HW11.Task2.Services;
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
            LoggingService.AddEventToLog("Motorcycle has been added to DB");
        }

        public void DeleteMotorcycle(Motorcycle item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
            LoggingService.AddEventToLog("Motorcycle has been deleted from DB");
        }

        public Motorcycle GetMotorcycleByID(int id)
        {
            LoggingService.AddEventToLog($"Returned motorcycle with id={id} from DB");
            return GetMotorcycles().FirstOrDefault(i => i.ID.Equals(id));
        }

        public IEnumerable<Motorcycle> GetMotorcycles()
        {
            LoggingService.AddEventToLog("Returned all motorcycles from DB");
            return _dbSet.AsNoTracking().ToList();
        } 

        public void UpdateMotorcycle(Motorcycle item)
        {
            LoggingService.AddEventToLog("Motorcycle has been updated in DB");
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
