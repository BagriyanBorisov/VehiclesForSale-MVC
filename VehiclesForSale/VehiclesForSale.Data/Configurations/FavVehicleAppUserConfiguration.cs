﻿namespace VehiclesForSale.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models.VehicleModel;

    public class FavVehicleAppUserConfiguration : IEntityTypeConfiguration<FavoriteVehicleApplicationUser>
    {
        public void Configure(EntityTypeBuilder<FavoriteVehicleApplicationUser> builder)
        {
            builder
                .HasKey(kvp => new { kvp.ApplicationUserId, kvp.VehicleId });

            builder
                .HasOne(v => v.ApplicationUser)
                .WithMany(v => v.FavoriteVehicleApplicationUsers)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(v => v.Vehicle)
                .WithMany(v => v.FavoriteVehicleApplicationUsers)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
