using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Car_Wiki.Model.Classes
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }
        public double Motor { get; set; }
        public int Hp { get; set; }
        public string Info { get; set; }
    }

    public class CarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=CarsDB;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

}
