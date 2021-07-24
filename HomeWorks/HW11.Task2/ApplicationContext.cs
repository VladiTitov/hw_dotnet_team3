using HW11.Task2.Models;
using Microsoft.EntityFrameworkCore;

namespace HW11.Task2
{
    class ApplicationContext : DbContext
    {
        public DbSet<Motorcycle> Motorcycles { get; set; }

        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite(@"Data Source=..\\Transport.db");
    }
}
