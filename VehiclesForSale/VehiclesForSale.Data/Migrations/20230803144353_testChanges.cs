using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehiclesForSale.Data.Migrations
{
    public partial class testChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ExtraId",
                table: "SafetyExtras",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ExtraId",
                table: "OtherExtras",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ExtraId",
                table: "InteriorExtras",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ExtraId",
                table: "ExteriorExtras",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ExtraId",
                table: "ComfortExtras",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1059c3a8-ab81-4b3d-9254-d57a3e0303d5", "AQAAAAEAACcQAAAAEDt9viGCcziqEiwX0pXiQIJFOXR1T4T+6sA1MDLymsMddfkgd2fLY8J9ENJPJ/mang==", "39df0c26-c947-4eef-a038-54f59e2e56b1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a123as23-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "665ca9e8-bc18-4b5a-848d-67cba66c7f58", "AQAAAAEAACcQAAAAEIGvE6HjeWzxYW4EUy5m5xfaeXbhfLV2GdbX1eQVZaoobP4fAW0HVZ+PiMheGwgvHw==", "5572bf61-b73b-450a-8a73-713c5a0f9b31" });

            migrationBuilder.UpdateData(
                table: "ComfortExtras",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExtraId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComfortExtras",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExtraId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComfortExtras",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExtraId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComfortExtras",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExtraId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComfortExtras",
                keyColumn: "Id",
                keyValue: 5,
                column: "ExtraId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ExteriorExtras",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExtraId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ExteriorExtras",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExtraId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ExteriorExtras",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExtraId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ExteriorExtras",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExtraId",
                value: null);

            migrationBuilder.UpdateData(
                table: "InteriorExtras",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExtraId",
                value: null);

            migrationBuilder.UpdateData(
                table: "InteriorExtras",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExtraId",
                value: null);

            migrationBuilder.UpdateData(
                table: "InteriorExtras",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExtraId",
                value: null);

            migrationBuilder.UpdateData(
                table: "InteriorExtras",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExtraId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OtherExtras",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExtraId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OtherExtras",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExtraId",
                value: null);

            migrationBuilder.UpdateData(
                table: "SafetyExtras",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExtraId",
                value: null);

            migrationBuilder.UpdateData(
                table: "SafetyExtras",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExtraId",
                value: null);

            migrationBuilder.UpdateData(
                table: "SafetyExtras",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExtraId",
                value: null);

            migrationBuilder.UpdateData(
                table: "SafetyExtras",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExtraId",
                value: null);

            migrationBuilder.UpdateData(
                table: "SafetyExtras",
                keyColumn: "Id",
                keyValue: 5,
                column: "ExtraId",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ExtraId",
                table: "SafetyExtras",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExtraId",
                table: "OtherExtras",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExtraId",
                table: "InteriorExtras",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExtraId",
                table: "ExteriorExtras",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExtraId",
                table: "ComfortExtras",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f403814-7968-4f77-b1dc-6eb3fd03649e", "AQAAAAEAACcQAAAAEISSwphqwFGhtd3GCMIboVdAvfvyDQUwp8Wz+RcP4N1CmRdBUdU6FBot0ueQrowX6A==", "2336ae71-6559-411e-aae6-17d02244bd80" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a123as23-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0355f9a8-ab28-41bc-a307-9872e5e85649", "AQAAAAEAACcQAAAAEMdP3sJ0K2M+rM+XnFmFA1j/3c788hpvjRqs99Xu37Ffp/DsTyBhwdNC8ZrkXSAFhw==", "8122d986-2939-4bd3-9cff-0ba98702b54b" });

            migrationBuilder.UpdateData(
                table: "ComfortExtras",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExtraId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ComfortExtras",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExtraId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ComfortExtras",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExtraId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ComfortExtras",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExtraId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ComfortExtras",
                keyColumn: "Id",
                keyValue: 5,
                column: "ExtraId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ExteriorExtras",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExtraId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ExteriorExtras",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExtraId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ExteriorExtras",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExtraId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ExteriorExtras",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExtraId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "InteriorExtras",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExtraId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "InteriorExtras",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExtraId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "InteriorExtras",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExtraId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "InteriorExtras",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExtraId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "OtherExtras",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExtraId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "OtherExtras",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExtraId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SafetyExtras",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExtraId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SafetyExtras",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExtraId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SafetyExtras",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExtraId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SafetyExtras",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExtraId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SafetyExtras",
                keyColumn: "Id",
                keyValue: 5,
                column: "ExtraId",
                value: 0);
        }
    }
}
