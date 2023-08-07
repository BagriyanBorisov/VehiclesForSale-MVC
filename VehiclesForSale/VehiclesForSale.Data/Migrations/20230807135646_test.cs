using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehiclesForSale.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "00a60186-5cac-4a98-974d-c4e90328a9df", "AQAAAAEAACcQAAAAEChvo/xsA9EjXx+pePb6Sk7PFx7C6a8UAQ8/6BOPH37e5Cwe8FRQzAimsEux358p4A==", "8e61014a-f4d5-47eb-beb6-8bb80b64035a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a123as23-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7db815e-a91b-4129-86a4-548d71581343", "AQAAAAEAACcQAAAAEEysxwax/4mIILOxUCfx7g6b0EkwsJb2KIg1GzaYjqqxJ0DaX+t9YGHLQRvxxtf+VA==", "2732d6e0-c16d-44fc-9fc9-c78fc905d29f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba0c6387-e5aa-4260-b632-8f556c6304ee", "AQAAAAEAACcQAAAAEHtk1c6tqXRRSBFaDfK3d3FlZJaHMVEqg2yg7Ycih8J3UmdDwj+DkXAk3CUlNJ9Mvw==", "2bb63d9c-a029-40f4-a79c-9755cc5d53e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a123as23-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "151a09f0-80cb-4bd0-9200-8872caff0286", "AQAAAAEAACcQAAAAEOPIY3pkG3xs8p4UX7DSPr3Bqgak669Pc554pZe+nP52j3RQUSgfl9ocg2cmWJUntA==", "e5ee16ea-026a-4289-afb5-72b78fdcadb6" });
        }
    }
}
