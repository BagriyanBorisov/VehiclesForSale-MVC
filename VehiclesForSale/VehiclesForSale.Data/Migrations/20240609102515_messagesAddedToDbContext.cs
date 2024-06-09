using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehiclesForSale.Data.Migrations
{
    /// <inheritdoc />
    public partial class messagesAddedToDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_AspNetUsers_SenderId",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Messages");

            migrationBuilder.RenameIndex(
                name: "IX_Message_SenderId",
                table: "Messages",
                newName: "IX_Messages_SenderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "a14d695d-341f-4a36-b94e-50df7ba591fc", "AQAAAAIAAYagAAAAELAhwhVANW93VnzZd91MArhlrFB5/KtrebktkX4mfd1o6eE6XX5DWaI6pnImLsGGTQ==", new DateTime(2024, 6, 9, 10, 25, 13, 814, DateTimeKind.Utc).AddTicks(8898), "201ef501-ec6b-4f8c-9459-147b58afa2ca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a123as23-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "ca9c43f1-2051-43ed-8178-11a8926e1ea7", "AQAAAAIAAYagAAAAEC6Yb/UwWhiWxW8KTzXfLOsD6f355ZdScQWweM23M8eluiczm4x5GaNpQ18aTwYaYQ==", new DateTime(2024, 6, 9, 10, 25, 13, 862, DateTimeKind.Utc).AddTicks(4807), "4a420664-1939-4750-8058-3910313898d3" });

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_SenderId",
                table: "Message",
                newName: "IX_Message_SenderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "5d9b790c-8511-415f-b30f-173b9fefe6ec", "AQAAAAIAAYagAAAAEJ5/1tEo+bwQvTr4aF3pxnyE7xP/wQ+yT9gD6NJI14pwgmb753dkxpcPR7BLCm4U9A==", new DateTime(2024, 6, 8, 17, 39, 0, 856, DateTimeKind.Utc).AddTicks(9117), "e0e5cdcd-47b1-43d9-bbd8-6da94549b908" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a123as23-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "d79cbb25-689c-462c-a1c0-c1b5198a68ea", "AQAAAAIAAYagAAAAEAAPREvSv/qR8LOZosFlvJO6kUE8N0moNh3CwzGRZLUFG244RKe+sKyueH67btImpQ==", new DateTime(2024, 6, 8, 17, 39, 0, 909, DateTimeKind.Utc).AddTicks(952), "92bd4ae1-1c8c-4a47-ac1f-d1c79ce0c7be" });

            migrationBuilder.AddForeignKey(
                name: "FK_Message_AspNetUsers_SenderId",
                table: "Message",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
