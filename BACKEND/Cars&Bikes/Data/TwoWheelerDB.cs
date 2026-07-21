using Cars_Bikes.Models;
using Google.Apis.Discovery;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Cars_Bikes.Data
{
    //public class TwoWheelerDB : IdentityDbContext<ApplicationUser>
     public class TwoWheelerDB : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public TwoWheelerDB(DbContextOptions<TwoWheelerDB> options) : base(options)
        {

        }
        public DbSet<TwoWheelerBrand> TwowheelerBrands { get; set; }
        public DbSet<TwoWheeler> Twowheelers { get; set; }
        public DbSet<TWSpec> TWSpec { get; set; }
        public DbSet<TWFeatures> TWFeatures { get; set; }
        public DbSet<TWSafety> TWSafety { get; set; }
        public DbSet<TWEngineAndTransmission> TWEngineAndTransmissions { get; set; }
        public DbSet<TWMileageAndPerformance> TWMileageAndPerformances { get; set; }
        public DbSet<TWChassisAndSuspension> TWChassisAndSuspensions { get; set; }
        public DbSet<TWDimensionsAndCapacity> TWDimensionsAndCapacities { get; set; }
        public DbSet<TWElectricals> TWElectricals { get; set; }
        public DbSet<TWTyresAndBrakes> TWTyresAndBrakes { get; set; }
        public DbSet<TWMotorAndBattery> TWMotorAndBatteries { get; set; }
        public DbSet<TWUnderpinning> TWUnderpinnings { get; set; }
        public DbSet<TWCharging> TWChargings { get; set; }
        public DbSet<TWLatestNews> TWLatestNews { get; set; }
        public DbSet<UpcomingBike> UpcomingBikes { get; set; }
        public DbSet<TWVarient> TWVarients { get; set; }
        public DbSet<TWImageColorPrice> TWImageColorPrices { get; set; }
        public DbSet<TWOrFWContactUs> TWOrFWContactUs { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<Blogs> Blogs { get; set; }
        public DbSet<LoginModel> LoginModel { get; set; }
        public DbSet<ValueForMoney> ValueForMoney { get; set; }
        public DbSet<TWEVEngineAndTransmission> TWEVEngineAndTransmissions { get; set; }
        public DbSet<TWEVFeatures> TWEVFeatures { get; set; }
        public DbSet<TWEVSafety> TWEVSafety { get; set; }
        public DbSet<TWEVChassisAndSuspension> TWEVChassisAndSuspensions { get; set; }
        public DbSet<TWEVDimensionsAndCapacity> TWEVDimensionsAndCapacities { get; set; }
        public DbSet<TWEVElectricals> TWEVElectricals { get; set; }
        public DbSet<TWEVTyresAndBrakes> TWEVTyresAndBrakes { get; set; }
        public DbSet<TWEVPerformance> TWEVPerformances { get; set; }
        public DbSet<TWEVMotorAndBattery> TWEVMotorAndBatteries { get; set; }
        public DbSet<TWEVRange> TWEVRanges { get; set; }
        public DbSet<TWEVCharging> TWEVChargings { get; set; }
        public DbSet<TWEVUnderpinning> TWEVUnderpinnings { get; set; }
        public DbSet<TWEVAppFeatures> TWEVAppFeatures { get; set; }
        public DbSet<CompareItems> CompareItems { get; set; }
        public DbSet<Wishlist> Wishlist { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TwoWheelerBrand>().HasKey(t => t.TWBrandId);
            modelBuilder.Entity<TwoWheeler>().HasOne(s => s.TwoWheelerBrands).WithMany(b => b.TwoWheelers).HasForeignKey(s => s.TwoWBrandId).OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Review>()
            .HasOne(r => r.TwoWheeler)
            .WithMany()
            .HasForeignKey(r => r.TwoWheelerID)
            .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
