﻿namespace VehiclesForSale.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Models.VehicleModel;
    using Models.VehicleModel.Extras;
    using System.Reflection;


    public class VehiclesDbContext : IdentityDbContext<ApplicationUser>
    {
        public VehiclesDbContext(DbContextOptions<VehiclesDbContext> options)
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
        public DbSet<Date> Dates { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            Assembly configAssembly = Assembly.GetAssembly(typeof(VehiclesDbContext)) ?? Assembly.GetExecutingAssembly();
            modelBuilder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}