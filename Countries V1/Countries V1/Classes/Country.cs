using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Countries_V1.Classes
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearCreated { get; set; }
        public string GovernmentType { get; set; }
        public string MapImageUrl { get; set; }
        public long Population { get; set; }
        public double Area { get; set; }
        public decimal GDP { get; set; }
    }

    public class CountryContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=CountriesDB;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
    
}
