using Cars_Bikes.Models;
using Microsoft.EntityFrameworkCore;

namespace Cars_Bikes.Data
{
    public class FourWheelerDB:DbContext
    {
        public FourWheelerDB(DbContextOptions<FourWheelerDB> options) : base(options)
        {
           
        }
        public DbSet<FourWheelerBrand> FourWheelerBrands { get; set; }
        public DbSet<FWLatestNews> FWLatestNews { get; set; }
        public DbSet<UpcomingCar> UpcomingCars { get; set; }
    }
}
