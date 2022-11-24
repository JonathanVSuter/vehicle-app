using Microsoft.EntityFrameworkCore;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Infra.Repositories.EF
{
    public class AppVehiclesDbContext : DbContext
    {
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<AnnouncementImage> AnnouncementImages { get; set; }
        public AppVehiclesDbContext(DbContextOptions<AppVehiclesDbContext> dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Vehicle>(e =>
                {
                    e.HasKey(x => x.Id);
                    e.HasMany(x => x.Announcements).WithOne(y => y.Vehicle).HasForeignKey(z => z.IdVehicle);                    
                })
                .Entity<User>(e =>
                {
                    e.HasKey(x => x.Id);
                    e.HasMany(x => x.Announcements).WithOne(y => y.User).HasForeignKey(y => y.IdUser);
                })
                .Entity<Announcement>(e =>
                {
                    e.HasKey(x => x.Id);
                    e.HasOne(x => x.User).WithMany(y => y.Announcements).HasForeignKey(z => z.IdUser);
                    e.HasOne(x => x.Vehicle).WithMany(y => y.Announcements).HasForeignKey(z => z.IdVehicle);
                    e.HasMany(x => x.AnnouncementImages).WithOne(y => y.Announcement).HasForeignKey(z => z.IdAnnouncement);
                })
                .Entity<AnnouncementImage>(e =>
                {
                    e.HasKey(x => x.Id);
                    e.HasOne(x => x.Announcement).WithMany(y => y.AnnouncementImages).HasForeignKey(z => z.IdAnnouncement);
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
