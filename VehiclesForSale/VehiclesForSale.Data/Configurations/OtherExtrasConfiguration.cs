namespace VehiclesForSale.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models.VehicleModel.Extras;

    public class OtherExtrasConfiguration : IEntityTypeConfiguration<OtherExtra>
    {
        public void Configure(EntityTypeBuilder<OtherExtra> builder)
        {
            builder
                .HasOne(v => v.Extra)
                .WithMany(v => v.OtherExtras)
                .HasForeignKey(v => v.ExtraId) // Assuming ExtraId is the foreign key in child extras
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(Seed());
        }

        private IEnumerable<OtherExtra> Seed()
        {
            List<OtherExtra> otherExtras = new List<OtherExtra>
            {
                new OtherExtra { Name = "LPG", Id = 1 },
                new OtherExtra { Name = "4x4", Id = 2 },

            };

            return otherExtras;
        }
    }
}