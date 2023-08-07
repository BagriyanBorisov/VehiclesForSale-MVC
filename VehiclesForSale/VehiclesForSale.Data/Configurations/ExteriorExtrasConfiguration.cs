namespace VehiclesForSale.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models.VehicleModel.Extras;

    public class ExteriorExtrasConfiguration : IEntityTypeConfiguration<ExteriorExtra>
    {
        public void Configure(EntityTypeBuilder<ExteriorExtra> builder)
        {
            builder
                .HasOne(v => v.Extra)
                .WithMany(v => v.ExteriorExtras)
                .HasForeignKey(v => v.ExtraId) // Assuming ExtraId is the foreign key in child extras
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(Seed());
        }

        private IEnumerable<ExteriorExtra> Seed()
        {
            List<ExteriorExtra> exteriorExtras = new List<ExteriorExtra>
            {
                new ExteriorExtra { Name = "LED Headlights", Id = 1 },
                new ExteriorExtra { Name = "Power-Folding Side Mirrors", Id = 2 },
                new ExteriorExtra { Name = "Panoramic Roof", Id = 3 },
                new ExteriorExtra { Name = "Roof Rails", Id = 4 }
            };

            return exteriorExtras;
        }
    }
}