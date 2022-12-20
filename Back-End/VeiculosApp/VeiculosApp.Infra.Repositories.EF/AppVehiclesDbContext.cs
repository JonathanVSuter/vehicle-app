using Microsoft.EntityFrameworkCore;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Infra.Repositories.EF
{
    public class AppVehiclesDbContext : DbContext
    {
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<AdvertisementImage> AdvertisementImages { get; set; }
        public AppVehiclesDbContext(DbContextOptions<AppVehiclesDbContext> dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Vehicle>(e =>
                {
                    e.HasKey(x => x.Id);
                    e.HasMany(x => x.Advertisement).WithOne(y => y.Vehicle).HasForeignKey(z => z.IdVehicle);                    
                })
                .Entity<User>(e =>
                {
                    e.HasKey(x => x.Id);
                    e.HasMany(x => x.Advertisements).WithOne(y => y.User).HasForeignKey(y => y.IdUser);
                })
                .Entity<Advertisement>(e =>
                {
                    e.HasKey(x => x.Id);
                    e.HasOne(x => x.User).WithMany(y => y.Advertisements).HasForeignKey(z => z.IdUser);
                    e.HasOne(x => x.Vehicle).WithMany(y => y.Advertisement).HasForeignKey(z => z.IdVehicle);
                    e.HasMany(x => x.Images).WithOne(y => y.Advertisement).HasForeignKey(z => z.IdAdvertisement);
                })
                .Entity<AdvertisementImage>(e =>
                {
                    e.HasKey(x => x.Id);
                    e.HasOne(x => x.Advertisement).WithMany(y => y.Images).HasForeignKey(z => z.IdAdvertisement);
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
