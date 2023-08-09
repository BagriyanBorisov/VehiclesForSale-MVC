namespace VehiclesForSale.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models.VehicleModel;
    using Models.VehicleModel.Enums;

    public class DateConfiguration : IEntityTypeConfiguration<Date>
    {
        public void Configure(EntityTypeBuilder<Date> builder)
        {
            int currentId = 1; // Start the ID from 1000 or any other value you prefer

            // Seed the database with years from 1930 to 2023
            for (int year = 1930; year <= 2023; year++)
            {
                for (int month = 1; month <= 12; month++)
                {
                    builder.HasData(
                        new Date { Id = currentId++, Year = year, Month = (Month)month }
                    );
                }
            }
        }

    }
}