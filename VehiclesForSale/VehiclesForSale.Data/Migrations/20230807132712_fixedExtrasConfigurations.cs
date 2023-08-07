using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehiclesForSale.Data.Migrations
{
    public partial class fixedExtrasConfigurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1988ec2d-8971-4b83-91ea-9a37c83d39ac", "AQAAAAEAACcQAAAAEI4A+FyZCuBU57AZsUstxPbubMVL3kx6NlpPYM618JAfRwllCuWyF2SVYLhtRXkMsw==", "0f5dea60-1fb0-4a9c-bd4a-1a4a46d86bc2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a123as23-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b78db85-a3c0-439a-9546-e9f631ec92a7", "AQAAAAEAACcQAAAAEOY1t0CSPMy8i9E3bDSyW6SPY6RAA5Ci1eE/uRXCL/WMnvBF0EkhV0F2d86DR/z6QQ==", "fe4f4296-4810-474f-817d-df3f7a27300c" });
        }
    }
}
