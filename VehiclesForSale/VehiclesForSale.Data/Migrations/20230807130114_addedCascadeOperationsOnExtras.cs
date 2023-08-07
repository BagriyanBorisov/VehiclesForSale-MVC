using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehiclesForSale.Data.Migrations
{
    public partial class addedCascadeOperationsOnExtras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComfortExtras_Extras_ExtraId",
                table: "ComfortExtras");

            migrationBuilder.DropForeignKey(
                name: "FK_ExteriorExtras_Extras_ExtraId",
                table: "ExteriorExtras");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ComfortExtras_Extras_ExtraId",
                table: "ComfortExtras",
                column: "ExtraId",
                principalTable: "Extras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExteriorExtras_Extras_ExtraId",
                table: "ExteriorExtras",
                column: "ExtraId",
                principalTable: "Extras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComfortExtras_Extras_ExtraId",
                table: "ComfortExtras");

            migrationBuilder.DropForeignKey(
                name: "FK_ExteriorExtras_Extras_ExtraId",
                table: "ExteriorExtras");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa18481c-e746-4d14-93f3-fe9c8d13c943", "AQAAAAEAACcQAAAAEHxUfldCJ778XDwoxvF6ilf4GudWpmxVr3jYDDoZwRW8s/JTjG+B4QqQEzKrPRRTEw==", "7996937b-3b61-4a2e-9006-6f8a4cd380cf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a123as23-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d833e97e-7283-4c72-8ae8-950d7db6c228", "AQAAAAEAACcQAAAAEAhpzazDu8+wp5diEDjPbVGYrVl02kkbbBBdBVuI6lTFMx2wZSn/BPhbR3n6KRmflQ==", "1759ec40-c26c-473a-a716-80275716b01c" });

            migrationBuilder.AddForeignKey(
                name: "FK_ComfortExtras_Extras_ExtraId",
                table: "ComfortExtras",
                column: "ExtraId",
                principalTable: "Extras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExteriorExtras_Extras_ExtraId",
                table: "ExteriorExtras",
                column: "ExtraId",
                principalTable: "Extras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
