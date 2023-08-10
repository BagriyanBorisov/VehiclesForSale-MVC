using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehiclesForSale.Data.Migrations
{
    public partial class addedDateAddedPropertyToVehicleModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Vehicles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82152175-ac56-462b-8b59-394d73bc2c04", "AQAAAAEAACcQAAAAELvoYBiy6Z9UjW3h2zw2TTXdniv5CEatp+8ASgRxqZDU/JtzutiSmwtq9aCKMwF9Cg==", "cb6d63dc-e084-4bb6-bece-b7f23902d363" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a123as23-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "903bc681-8e76-4990-8546-f3a5234ce1bf", "AQAAAAEAACcQAAAAEIlzdVz/Rh2VA8iwdpMDmTpClaHw9W3VIthDLsiOhvZU0VAOvhpUtxOfROwaOrHcBQ==", "2e3e7ae8-3824-4395-829b-5dabad3351aa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Vehicles");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3e20f3b-60c0-4f71-aaec-c02ad205860d", "AQAAAAEAACcQAAAAEOEYfcym2MmptQFDwHXZo5d30lZcqGjkfAHkSdN8K507uK9dKd7SXYRlGh1zoJacHA==", "94946783-ceac-4860-9f2f-b7a50c6156df" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a123as23-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b9c64f9-685d-47c1-8a6f-34f01d5aa79a", "AQAAAAEAACcQAAAAEOG8YknCpPcmRVdEN0vkLYgefDVUcFKdV0lAu/swMo7CH35sqMyqnXynmxCnpe0H7g==", "769b1ebd-e7f0-4ad6-868f-1bfd37371683" });
        }
    }
}
