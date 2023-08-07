using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehiclesForSale.Data.Migrations
{
    public partial class addedOnDeleteCascadeFavVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteVehicleApplicationUsers_Vehicles_VehicleId",
                table: "FavoriteVehicleApplicationUsers");

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
                name: "FK_FavoriteVehicleApplicationUsers_Vehicles_VehicleId",
                table: "FavoriteVehicleApplicationUsers",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteVehicleApplicationUsers_Vehicles_VehicleId",
                table: "FavoriteVehicleApplicationUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c25d3b1f-57e1-4426-92f6-c59b0cd0eda1", "AQAAAAEAACcQAAAAELBEgqEYOJA11ydbpRL017T+EEr5fNZN3aJFv+p+y+xEcc7OLkqmCKDe3dkg/pdM5w==", "2e9c1bdd-e798-4057-87a6-d75048dfefbc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a123as23-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a423dbc6-013a-4587-b799-93e7c477b59f", "AQAAAAEAACcQAAAAEDmkLIWr81zoxQSfWsuvVyM46NHpX+gjte0/nCUx3cLGLG5B8rHZYDhjvwGx6x0W5w==", "e2f92873-1c1f-45e1-80b7-d77a6e288945" });

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteVehicleApplicationUsers_Vehicles_VehicleId",
                table: "FavoriteVehicleApplicationUsers",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }
    }
}
