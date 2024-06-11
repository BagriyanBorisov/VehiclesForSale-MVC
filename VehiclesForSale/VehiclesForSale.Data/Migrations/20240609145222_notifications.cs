using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehiclesForSale.Data.Migrations
{
    /// <inheritdoc />
    public partial class notifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReceiverId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_SenderId",
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
                values: new object[] { "64ed7160-31fd-4b6b-bf9a-26e91c691544", "AQAAAAIAAYagAAAAEBpUSsA92peR0YEvFcfU7LEd4wKpZvNXRE1Qzt/n4kDb+4BdHjGl2ZsFdt28YUZvVg==", new DateTime(2024, 6, 9, 14, 52, 21, 151, DateTimeKind.Utc).AddTicks(1168), "e6c6a929-e4b3-4953-aecd-886c62a15616" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a123as23-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "6bb6a046-a403-4a19-8b40-c9e9056e55c1", "AQAAAAIAAYagAAAAEGP89AVHQ8r/tbanMiUp0uuUdtNeHuWIw2cSrasdrJGxiM4OfTkElwb00fd2ezZw0w==", new DateTime(2024, 6, 9, 14, 52, 21, 199, DateTimeKind.Utc).AddTicks(781), "d82fd3a0-e28b-4501-93ac-d86b8996b69d" });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_SenderId",
                table: "Notifications",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

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
        }
    }
}
