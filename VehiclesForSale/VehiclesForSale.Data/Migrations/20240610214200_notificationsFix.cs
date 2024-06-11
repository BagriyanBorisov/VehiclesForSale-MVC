using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehiclesForSale.Data.Migrations
{
    /// <inheritdoc />
    public partial class notificationsFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_SenderId",
                table: "Notifications");

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverId",
                table: "Notifications",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "23665293-3761-4876-ba8e-ae30fa8dd7fa", "AQAAAAIAAYagAAAAEOqyTGgiONoe4ebwl6mjcL31qCzhorUBhhBdrP9aSqnxyLnQa8qePlsTsFAOFUt/IQ==", new DateTime(2024, 6, 10, 21, 41, 59, 541, DateTimeKind.Utc).AddTicks(7165), "29616d0b-da19-46ed-bcce-c0ce28681151" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a123as23-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "8d7d2fd6-32e4-4eff-b6d4-03c8a44ac41c", "AQAAAAIAAYagAAAAEFfIpExjXHzV8swvI5THmoXPZh48JLfdtOgtsC7R3XBfVE8daeWeWzlgAXnzPVc2VQ==", new DateTime(2024, 6, 10, 21, 41, 59, 593, DateTimeKind.Utc).AddTicks(7651), "8a9cb240-1808-4823-a984-c92a759f6ab8" });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ReceiverId",
                table: "Notifications",
                column: "ReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_ReceiverId",
                table: "Notifications",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_SenderId",
                table: "Notifications",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_ReceiverId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_SenderId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_ReceiverId",
                table: "Notifications");

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverId",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "9057ce30-ca6f-484a-9d2d-049fb80f0621", "AQAAAAIAAYagAAAAENGVl8Ge3dp9sSXmecd4DvLfvWHsv4O8Wbwzs0ZrS5TxX2Y9EO18a4zPW/BLkZiqeA==", new DateTime(2024, 6, 9, 14, 53, 44, 107, DateTimeKind.Utc).AddTicks(8159), "30a7c568-3dc9-49fc-b921-e645c3ae8df3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a123as23-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "ce9631fc-5038-4293-872e-8d0bce938fc1", "AQAAAAIAAYagAAAAEBzLLmVqOzV9TuGg6kJuzMVmioTrUuf63p341bK5wCf1Qw8rDrmATvlskJ7FKUEgMw==", new DateTime(2024, 6, 9, 14, 53, 44, 170, DateTimeKind.Utc).AddTicks(1417), "992571db-c6ce-49bd-b235-4fdf02657e8f" });

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_SenderId",
                table: "Notifications",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
