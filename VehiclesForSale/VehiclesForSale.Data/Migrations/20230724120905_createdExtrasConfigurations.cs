using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehiclesForSale.Data.Migrations
{
    public partial class createdExtrasConfigurations : Migration
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

            migrationBuilder.InsertData(
                table: "ComfortExtras",
                columns: new[] { "Id", "ExtraId", "Name" },
                values: new object[,]
                {
                    { 1, null, "Multi-Zone Climate Control" },
                    { 2, null, "Power-adjustable Seats with Memory Function" },
                    { 3, null, "Heated and Ventilated Seats" },
                    { 4, null, "Adaptive Cruise Control" },
                    { 5, null, "Power Lift gate or Hands-Free Lift gate" }
                });

            migrationBuilder.InsertData(
                table: "ExteriorExtras",
                columns: new[] { "Id", "ExtraId", "Name" },
                values: new object[,]
                {
                    { 1, null, "LED Headlights" },
                    { 2, null, "Power-Folding Side Mirrors" },
                    { 3, null, "Panoramic Roof" },
                    { 4, null, "Roof Rails" }
                });

            migrationBuilder.InsertData(
                table: "InteriorExtras",
                columns: new[] { "Id", "ExtraId", "Name" },
                values: new object[,]
                {
                    { 1, null, "Heated Seats" },
                    { 2, null, "Panoramic Sunroof" },
                    { 3, null, "Infotainment System" },
                    { 4, null, "Key less Entry and Push-Button Start" }
                });

            migrationBuilder.InsertData(
                table: "OtherExtras",
                columns: new[] { "Id", "ExtraId", "Name" },
                values: new object[,]
                {
                    { 1, null, "LPG" },
                    { 2, null, "4x4" }
                });

            migrationBuilder.InsertData(
                table: "SafetyExtras",
                columns: new[] { "Id", "ExtraId", "Name" },
                values: new object[,]
                {
                    { 1, null, "Anti-lock Braking System (ABS)" },
                    { 2, null, "Electronic Stability Control (ESC)" },
                    { 3, null, "Blind Spot Monitoring (BSM) System" },
                    { 4, null, "Lane Departure Warning (LDW)" },
                    { 5, null, "Lane Keeping Assist (LKA)" }
                });

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

            migrationBuilder.DeleteData(
                table: "ComfortExtras",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ComfortExtras",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ComfortExtras",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ComfortExtras",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ComfortExtras",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ExteriorExtras",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExteriorExtras",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExteriorExtras",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ExteriorExtras",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "InteriorExtras",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "InteriorExtras",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InteriorExtras",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "InteriorExtras",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OtherExtras",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OtherExtras",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SafetyExtras",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SafetyExtras",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SafetyExtras",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SafetyExtras",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SafetyExtras",
                keyColumn: "Id",
                keyValue: 5);

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
                values: new object[] { "5aad42cf-5046-4a84-b65b-ac8771d25594", "AQAAAAEAACcQAAAAECGjfLN9TRrEz2UeSCeydgNCjtvEV35COXHWzXJbGfN3JCemTGG3um0N1bJZxdJfyg==", "fb1325c4-a252-4601-9f44-ef17826388a1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a123as23-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2a4f21b-06b2-4e62-bb87-f57c1391e2f6", "AQAAAAEAACcQAAAAEKVqnGdHp/82f8AQLwj0PYI9R/JAgD6xPWmQtSDx+RypCR42Dgjym80kPJUn/kCqIw==", "4e3ddace-fb59-4bc7-a545-3386de095185" });

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
