using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using VehiclesForSale.Data.Models;
using VehiclesForSale.Data.Models.VehicleModel;
using VehiclesForSale.Data.Models.VehicleModel.Extras;

namespace VehiclesForSale.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<Make> Makes { get; set; } = null!;
        public DbSet<Model> Models { get; set; } = null!;
        public DbSet<FuelType> FuelTypes { get; set; } = null!;
        public DbSet<TransmissionType> TransmissionTypes { get; set; } = null!;
        public DbSet<Image> Images { get; set; } = null!;
        public DbSet<Extra> Extras { get; set; } = null!;
        public DbSet<SafetyExtra> SafetyExtras { get; set; } = null!;
        public DbSet<ComfortExtra> ComfortExtras { get; set; } = null!;
        public DbSet<ExteriorExtra> ExteriorExtras { get; set; } = null!;
        public DbSet<InteriorExtra> InteriorExtras { get; set; } = null!;
        public DbSet<OtherExtra> OtherExtras { get; set; } = null!;
        public DbSet<CategoryType> CategoryTypes { get; set; } = null!;
        public DbSet<Color> Colors { get; set; } = null!;
        public DbSet<FavoriteVehicleApplicationUser> FavoriteVehicleApplicationUsers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Owner)
                .WithMany(ap => ap.VehiclesCollectionForSale)
                .HasForeignKey(v => v.OwnerId);

            modelBuilder.Entity<ApplicationUser>().HasMany(ap => ap.VehiclesCollectionForSale).WithOne(v => v.Owner);

            modelBuilder.Entity<FavoriteVehicleApplicationUser>().HasKey(kvp => new {kvp.ApplicationUserId,kvp.VehicleId});



            base.OnModelCreating(modelBuilder);
        }
    }
}