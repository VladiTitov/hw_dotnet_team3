using HM12.Task1.Models;
using Microsoft.EntityFrameworkCore;

namespace HM12.Task1
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Motorcycle> Motorcycles { get; set; }

        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite(@"Data Source=..\\Transport.db");

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite(@"Data Source=Transport.db");
    }
}
