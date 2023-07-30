using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehiclesForSale.Data.Migrations
{
    public partial class addedextraidpropertiesforExtras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComfortExtras_Extras_ExtraId",
                table: "ComfortExtras");

            migrationBuilder.DropForeignKey(
                name: "FK_ExteriorExtras_Extras_ExtraId",
                table: "ExteriorExtras");

            migrationBuilder.DropForeignKey(
                name: "FK_InteriorExtras_Extras_ExtraId",
                table: "InteriorExtras");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherExtras_Extras_ExtraId",
                table: "OtherExtras");

            migrationBuilder.DropForeignKey(
                name: "FK_SafetyExtras_Extras_ExtraId",
                table: "SafetyExtras");

            migrationBuilder.AlterColumn<int>(
                name: "ExtraId",
                table: "SafetyExtras",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExtraId",
                table: "OtherExtras",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExtraId",
                table: "InteriorExtras",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExtraId",
                table: "ExteriorExtras",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExtraId",
                table: "ComfortExtras",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2205bf1-bb1c-4ecc-8f69-7756fa268488", "AQAAAAEAACcQAAAAEOq1d+HqjoCsMBcWYuTRPEwjuKT3ERuvLy1NP2Nzt5j+1r71kFz0WynjkkN36ovmLA==", "66c43e0f-6dec-4748-8ed3-7aab44bc5dd6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a123as23-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a0564ca-9e91-4387-babc-1c4933a94da7", "AQAAAAEAACcQAAAAED6CmONk+5+204RgxQpw1DXUwRFQz946XIsjpGX1kleFXBgsglb3yfHAMy+NGRP9Sw==", "3c8c609c-6770-41aa-bda0-9d7253450edc" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_InteriorExtras_Extras_ExtraId",
                table: "InteriorExtras",
                column: "ExtraId",
                principalTable: "Extras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OtherExtras_Extras_ExtraId",
                table: "OtherExtras",
                column: "ExtraId",
                principalTable: "Extras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SafetyExtras_Extras_ExtraId",
                table: "SafetyExtras",
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

            migrationBuilder.DropForeignKey(
                name: "FK_InteriorExtras_Extras_ExtraId",
                table: "InteriorExtras");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherExtras_Extras_ExtraId",
                table: "OtherExtras");

            migrationBuilder.DropForeignKey(
                name: "FK_SafetyExtras_Extras_ExtraId",
                table: "SafetyExtras");

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
                values: new object[] { "30ea5e2e-7f4b-4f39-8a62-61adad7ad875", "AQAAAAEAACcQAAAAEKJlvhuwH8UbTEbg++Nn172pGi3TCmno2jGptZPEpiOAxOaMdB4gTaoTWuf7xYxa2w==", "5a1ba5da-67c3-4cbd-8909-329d8bbd1bc8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a123as23-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "271e4639-12bf-48ae-bf43-c50c545d05cb", "AQAAAAEAACcQAAAAEPzl1J6DrVZpNUvRt1JjfoIvDa6Q/mnF3S801OpG0U9JE2eUlZgejCG1NRADnRQKiA==", "a88f5816-3800-4936-bcc6-c8664a12c735" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_ComfortExtras_Extras_ExtraId",
                table: "ComfortExtras",
                column: "ExtraId",
                principalTable: "Extras",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExteriorExtras_Extras_ExtraId",
                table: "ExteriorExtras",
                column: "ExtraId",
                principalTable: "Extras",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InteriorExtras_Extras_ExtraId",
                table: "InteriorExtras",
                column: "ExtraId",
                principalTable: "Extras",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OtherExtras_Extras_ExtraId",
                table: "OtherExtras",
                column: "ExtraId",
                principalTable: "Extras",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SafetyExtras_Extras_ExtraId",
                table: "SafetyExtras",
                column: "ExtraId",
                principalTable: "Extras",
                principalColumn: "Id");
        }
    }
}
