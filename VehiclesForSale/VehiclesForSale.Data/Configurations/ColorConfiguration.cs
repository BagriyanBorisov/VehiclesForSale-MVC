namespace VehiclesForSale.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models.VehicleModel;

    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasData(Seed());
        }

        private IEnumerable<Color> Seed()
        {
            List<Color> colors = new List<Color>
            {
                new Color { Name = "Any", Id = 1 },
                new Color { Name = "Black", Id = 2 },
                new Color { Name = "Gray", Id = 3 },
                new Color { Name = "Silver", Id = 4 },
                new Color { Name = "Blue", Id = 5},
                new Color { Name = "Red", Id = 6 },
                new Color { Name = "Brown", Id = 7 },
                new Color { Name = "Green", Id = 8 },
                new Color { Name = "Orange", Id = 9 },
                new Color { Name = "Beige", Id = 10 },
                new Color { Name = "Purple", Id = 11 },
                new Color { Name = "Gold", Id = 12 },
                new Color { Name = "Yellow", Id = 13 },
                new Color { Name = "White", Id = 14 }
            };

            return colors;
        }
    }
}
