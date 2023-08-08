using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehiclesForSale.Data.Migrations
{
    public partial class updateUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "68784910-46f9-4bba-860b-525a49c7c89b", "PESHO.PESHEV@ABV.bg", "AQAAAAEAACcQAAAAEExiwu1P5fgDCzWWdixrIuoq8I8IlwA1U+Kgtt0VSxxziDYgcjlQb5GDWrDLtB7XSg==", "+359222222222", "bc2e8a9e-f555-409a-9858-5a7c81bf45a9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a123as23-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "69ce3163-1993-43ce-8d80-1bdb6a1a6cbc", "GOSHO.GOSHEV@ABV.BG", "AQAAAAEAACcQAAAAEHtg6U9IWzbRxJSVazN5qy3cR3arEh850rWetcnKrtGJTmga9KbGZ9uFJ9VJhnHajQ==", "+359111111111", "b468438e-bd14-4817-bf87-4b5bdd7c7814" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "00a60186-5cac-4a98-974d-c4e90328a9df", null, "AQAAAAEAACcQAAAAEChvo/xsA9EjXx+pePb6Sk7PFx7C6a8UAQ8/6BOPH37e5Cwe8FRQzAimsEux358p4A==", null, "8e61014a-f4d5-47eb-beb6-8bb80b64035a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a123as23-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "e7db815e-a91b-4129-86a4-548d71581343", null, "AQAAAAEAACcQAAAAEEysxwax/4mIILOxUCfx7g6b0EkwsJb2KIg1GzaYjqqxJ0DaX+t9YGHLQRvxxtf+VA==", null, "2732d6e0-c16d-44fc-9fc9-c78fc905d29f" });
        }
    }
}
