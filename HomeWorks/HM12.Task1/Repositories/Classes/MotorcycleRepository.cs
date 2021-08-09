using HM12.Task1.Models;
using HM12.Task1.Repositories.Interfaces;

namespace HM12.Task1.Repositories.Classes
{
    class MotorcycleRepository : GenericRepository<Motorcycle>, IMotorcycleRepository
    {
        public MotorcycleRepository(ApplicationContext context) : base(context) { }
    }
}
