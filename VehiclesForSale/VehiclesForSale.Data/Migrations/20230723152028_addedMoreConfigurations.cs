using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehiclesForSale.Data.Migrations
{
    public partial class addedMoreConfigurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "5aad42cf-5046-4a84-b65b-ac8771d25594", "Pesho.peshev@abv.bg", false, false, null, null, "pesho", "AQAAAAEAACcQAAAAECGjfLN9TRrEz2UeSCeydgNCjtvEV35COXHWzXJbGfN3JCemTGG3um0N1bJZxdJfyg==", null, false, "fb1325c4-a252-4601-9f44-ef17826388a1", false, "Pesho" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a123as23-a24d-4543-a6c6-9443d048cdb9", 0, "f2a4f21b-06b2-4e62-bb87-f57c1391e2f6", "Gosho.goshev@abv.bg", false, false, null, null, "gosho", "AQAAAAEAACcQAAAAEKVqnGdHp/82f8AQLwj0PYI9R/JAgD6xPWmQtSDx+RypCR42Dgjym80kPJUn/kCqIw==", null, false, "4e3ddace-fb59-4bc7-a545-3386de095185", false, "Gosho" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a123as23-a24d-4543-a6c6-9443d048cdb9");
        }
    }
}
