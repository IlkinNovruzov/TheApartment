using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TheApartment.Models.DataModels;

namespace TheApartment.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<ApartmentInfo> ApartmentInfos { get; set; }
        public DbSet<ApartmentImage> ApartmentImages { get; set; }
        public DbSet<ApartmentFeature> ApartmentFeatures { get; set; }
        public DbSet<Feature> Features { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApartmentFeature>().HasKey(af => new { af.ApartmentId, af.FeatureId });
            modelBuilder.Entity<ApartmentInfo>().HasData(
               new ApartmentInfo
               {
                   Id = 1,
                   ExtraInfo = "Our apartment is really clean and we like to keep it that way. Enjoy the lorem ipsum dolor sit amet  consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad",
                   Rules = "SLorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et",    
                   Email = "mail@mail.com",
                   Phone = "+994 099 777 77 77",
                   City="Baku"
               }
               );
            base.OnModelCreating(modelBuilder);
        }
    }
}
