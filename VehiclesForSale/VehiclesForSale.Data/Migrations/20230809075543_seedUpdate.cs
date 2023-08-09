using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehiclesForSale.Data.Migrations
{
    public partial class seedUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "FuelTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Any");

            migrationBuilder.UpdateData(
                table: "FuelTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Gasoline");

            migrationBuilder.UpdateData(
                table: "FuelTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Diesel");

            migrationBuilder.UpdateData(
                table: "FuelTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Electric");

            migrationBuilder.UpdateData(
                table: "FuelTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Hybrid(D/E)");

            migrationBuilder.UpdateData(
                table: "FuelTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Hybrid(G/E)");

            migrationBuilder.InsertData(
                table: "FuelTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "LPG" });

            migrationBuilder.UpdateData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Any");

            migrationBuilder.UpdateData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Mercedes-Benz");

            migrationBuilder.UpdateData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "BMW");

            migrationBuilder.UpdateData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Audi");

            migrationBuilder.InsertData(
                table: "Makes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Volkswagen" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Any");

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MakeId", "Name" },
                values: new object[] { 2, "W211" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "MakeId", "Name" },
                values: new object[] { 2, "W209" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "MakeId", "Name" },
                values: new object[] { 2, "W203" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "W219");

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "MakeId", "Name" },
                values: new object[] { 3, "E46" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "MakeId", "Name" },
                values: new object[] { 3, "E60" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "MakeId", "Name" },
                values: new object[] { 3, "E90" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "E39");

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "MakeId", "Name" },
                values: new object[] { 4, "A3" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "MakeId", "Name" },
                values: new object[] { 4, "A4" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "MakeId", "Name" },
                values: new object[] { 4, "A5" });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "MakeId", "Name" },
                values: new object[] { 13, 4, "A6" });

            migrationBuilder.UpdateData(
                table: "TransmissionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Any");

            migrationBuilder.UpdateData(
                table: "TransmissionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Manual");

            migrationBuilder.UpdateData(
                table: "TransmissionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Automatic");

            migrationBuilder.UpdateData(
                table: "TransmissionTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "CVT");

            migrationBuilder.InsertData(
                table: "TransmissionTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Semi-Automatic" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FuelTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TransmissionTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68784910-46f9-4bba-860b-525a49c7c89b", "AQAAAAEAACcQAAAAEExiwu1P5fgDCzWWdixrIuoq8I8IlwA1U+Kgtt0VSxxziDYgcjlQb5GDWrDLtB7XSg==", "bc2e8a9e-f555-409a-9858-5a7c81bf45a9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a123as23-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69ce3163-1993-43ce-8d80-1bdb6a1a6cbc", "AQAAAAEAACcQAAAAEHtg6U9IWzbRxJSVazN5qy3cR3arEh850rWetcnKrtGJTmga9KbGZ9uFJ9VJhnHajQ==", "b468438e-bd14-4817-bf87-4b5bdd7c7814" });

            migrationBuilder.UpdateData(
                table: "FuelTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Gasoline");

            migrationBuilder.UpdateData(
                table: "FuelTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Diesel");

            migrationBuilder.UpdateData(
                table: "FuelTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Electric");

            migrationBuilder.UpdateData(
                table: "FuelTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Hybrid(D/E)");

            migrationBuilder.UpdateData(
                table: "FuelTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Hybrid(G/E)");

            migrationBuilder.UpdateData(
                table: "FuelTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "LPG");

            migrationBuilder.UpdateData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Mercedes-Benz");

            migrationBuilder.UpdateData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "BMW");

            migrationBuilder.UpdateData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Audi");

            migrationBuilder.UpdateData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Volkswagen");

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "W211");

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MakeId", "Name" },
                values: new object[] { 1, "W209" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "MakeId", "Name" },
                values: new object[] { 1, "W203" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "MakeId", "Name" },
                values: new object[] { 1, "W219" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "E46");

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "MakeId", "Name" },
                values: new object[] { 2, "E60" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "MakeId", "Name" },
                values: new object[] { 2, "E90" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "MakeId", "Name" },
                values: new object[] { 2, "E39" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "A3");

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "MakeId", "Name" },
                values: new object[] { 3, "A4" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "MakeId", "Name" },
                values: new object[] { 3, "A5" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "MakeId", "Name" },
                values: new object[] { 3, "A6" });

            migrationBuilder.UpdateData(
                table: "TransmissionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Manual");

            migrationBuilder.UpdateData(
                table: "TransmissionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Automatic");

            migrationBuilder.UpdateData(
                table: "TransmissionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "CVT");

            migrationBuilder.UpdateData(
                table: "TransmissionTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Semi-Automatic");
        }
    }
}
