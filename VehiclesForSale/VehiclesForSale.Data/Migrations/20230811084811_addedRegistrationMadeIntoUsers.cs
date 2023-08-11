using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehiclesForSale.Data.Migrations
{
    public partial class addedRegistrationMadeIntoUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "81e6481b-c8dd-4a6a-becb-1f48c44a9385", "AQAAAAEAACcQAAAAEO/jQ5UqnYn1JRXoudRpjSAnubWRjys5oBCauJYNHNVCgV2VnBZCQ8yDFVz1x+OA8A==", new DateTime(2023, 8, 11, 8, 48, 10, 365, DateTimeKind.Utc).AddTicks(9588), "b4e20061-fcf1-4a75-9a04-a5f37ff2a004" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a123as23-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "b2222bbc-b5c8-4a67-91b5-3644cdd91d8f", "AQAAAAEAACcQAAAAEJjBTERTeLUO+QxzMBVgD4JUDlumipsBVI9j1aShuvF0mQ1GlGRJtJX8egnTHaySwQ==", new DateTime(2023, 8, 11, 8, 48, 10, 376, DateTimeKind.Utc).AddTicks(874), "8ea76317-168c-4987-bb4c-5f9ecd2d38c7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "AspNetUsers");

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
    }
}
