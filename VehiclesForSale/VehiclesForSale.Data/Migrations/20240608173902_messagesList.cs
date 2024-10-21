using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehiclesForSale.Data.Migrations
{
    /// <inheritdoc />
    public partial class messagesList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReceiverId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Message_SenderId",
                table: "Message",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "81e6481b-c8dd-4a6a-becb-1f48c44a9385", "AQAAAAEAACcQAAAAEO/jQ5UqnYn1JRXoudRpjSAnubWRjys5oBCauJYNHNVCgV2VnBZCQ8yDFVz1x+OA8A==", new DateTime(2023, 8, 11, 8, 48, 10, 365, DateTimeKind.Utc).AddTicks(9588), "b4e20061-fcf1-4a75-9a04-a5f37ff2a004" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a123as23-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "b2222bbc-b5c8-4a67-91b5-3644cdd91d8f", "AQAAAAEAACcQAAAAEJjBTERTeLUO+QxzMBVgD4JUDlumipsBVI9j1aShuvF0mQ1GlGRJtJX8egnTHaySwQ==", new DateTime(2023, 8, 11, 8, 48, 10, 376, DateTimeKind.Utc).AddTicks(874), "8ea76317-168c-4987-bb4c-5f9ecd2d38c7" });
        }
    }
}
