namespace VehiclesForSale.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models.VehicleModel.Extras;

    public class ExtraConfiguration : IEntityTypeConfiguration<Extra>
    {
        public void Configure(EntityTypeBuilder<Extra> builder)
        {

            builder.HasMany(e => e.ComfortExtras)
           .WithOne(ce => ce.Extra)
           .OnDelete(DeleteBehavior.Cascade);

            // Configure cascade delete for SafetyExtras
            builder.HasMany(e => e.SafetyExtras)
                .WithOne(se => se.Extra)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure cascade delete for ExteriorExtras
            builder.HasMany(e => e.ExteriorExtras)
                .WithOne(ee => ee.Extra)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure cascade delete for InteriorExtras
            builder.HasMany(e => e.InteriorExtras)
                .WithOne(ie => ie.Extra)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure cascade delete for OtherExtras
            builder.HasMany(e => e.OtherExtras)
                .WithOne(oe => oe.Extra)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}