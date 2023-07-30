using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehiclesForSale.Data.Migrations
{
    public partial class addedConfigurationUpdateForExtras : Migration
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f6c17bd-c27e-4706-8159-1a8675d387df", "AQAAAAEAACcQAAAAEAp7rqZYnIT03STIruObP6EJN1rcLgbTaD2+yRuq8DU4JXTtn7Dy/w4vESKOrxFxCA==", "145afc57-a6f9-4164-bb4b-255db3403953" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a123as23-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92a78097-2d2b-47d4-9d0b-6a31c6d2b1f0", "AQAAAAEAACcQAAAAEHQrATugH+XAYfZ9fqkFA/rS4L62/q7WhODLUVhdA0vq+zh3BlUlaISUqKZTrGdtIw==", "8c8e5789-2666-4213-b9d9-e2e8f9012e9c" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_InteriorExtras_Extras_ExtraId",
                table: "InteriorExtras",
                column: "ExtraId",
                principalTable: "Extras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OtherExtras_Extras_ExtraId",
                table: "OtherExtras",
                column: "ExtraId",
                principalTable: "Extras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SafetyExtras_Extras_ExtraId",
                table: "SafetyExtras",
                column: "ExtraId",
                principalTable: "Extras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
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
    }
}
