namespace VehiclesForSale.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models.VehicleModel.Extras;

    public class ComfortExtrasConfiguration : IEntityTypeConfiguration<ComfortExtra>
    {
        public void Configure(EntityTypeBuilder<ComfortExtra> builder)
        {
            builder
                .HasOne(v => v.Extra)
                .WithMany(v => v.ComfortExtras)
                .HasForeignKey(v => v.ExtraId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(Seed());
        }

        private IEnumerable<ComfortExtra> Seed()
        {
            List<ComfortExtra> comfortExtras = new List<ComfortExtra>
            {
                new ComfortExtra { Name = "Multi-Zone Climate Control", Id = 1 },
                new ComfortExtra { Name = "Power-adjustable Seats with Memory Function", Id = 2 },
                new ComfortExtra { Name = "Heated and Ventilated Seats", Id = 3 },
                new ComfortExtra { Name = "Adaptive Cruise Control", Id = 4 },
                new ComfortExtra { Name = "Power Lift gate or Hands-Free Lift gate", Id = 5 }
            };

            return comfortExtras;
        }
    }
}