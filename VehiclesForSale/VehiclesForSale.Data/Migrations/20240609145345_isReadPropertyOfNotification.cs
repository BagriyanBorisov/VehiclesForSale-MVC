using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehiclesForSale.Data.Migrations
{
    /// <inheritdoc />
    public partial class isReadPropertyOfNotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isRead",
                table: "Notifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "9057ce30-ca6f-484a-9d2d-049fb80f0621", "AQAAAAIAAYagAAAAENGVl8Ge3dp9sSXmecd4DvLfvWHsv4O8Wbwzs0ZrS5TxX2Y9EO18a4zPW/BLkZiqeA==", new DateTime(2024, 6, 9, 14, 53, 44, 107, DateTimeKind.Utc).AddTicks(8159), "30a7c568-3dc9-49fc-b921-e645c3ae8df3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a123as23-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "ce9631fc-5038-4293-872e-8d0bce938fc1", "AQAAAAIAAYagAAAAEBzLLmVqOzV9TuGg6kJuzMVmioTrUuf63p341bK5wCf1Qw8rDrmATvlskJ7FKUEgMw==", new DateTime(2024, 6, 9, 14, 53, 44, 170, DateTimeKind.Utc).AddTicks(1417), "992571db-c6ce-49bd-b235-4fdf02657e8f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isRead",
                table: "Notifications");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "64ed7160-31fd-4b6b-bf9a-26e91c691544", "AQAAAAIAAYagAAAAEBpUSsA92peR0YEvFcfU7LEd4wKpZvNXRE1Qzt/n4kDb+4BdHjGl2ZsFdt28YUZvVg==", new DateTime(2024, 6, 9, 14, 52, 21, 151, DateTimeKind.Utc).AddTicks(1168), "e6c6a929-e4b3-4953-aecd-886c62a15616" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a123as23-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "6bb6a046-a403-4a19-8b40-c9e9056e55c1", "AQAAAAIAAYagAAAAEGP89AVHQ8r/tbanMiUp0uuUdtNeHuWIw2cSrasdrJGxiM4OfTkElwb00fd2ezZw0w==", new DateTime(2024, 6, 9, 14, 52, 21, 199, DateTimeKind.Utc).AddTicks(781), "d82fd3a0-e28b-4501-93ac-d86b8996b69d" });
        }
    }
}
