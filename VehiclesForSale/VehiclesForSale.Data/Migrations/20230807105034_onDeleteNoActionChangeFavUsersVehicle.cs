using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehiclesForSale.Data.Migrations
{
    public partial class onDeleteNoActionChangeFavUsersVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteVehicleApplicationUsers_AspNetUsers_ApplicationUserId",
                table: "FavoriteVehicleApplicationUsers");

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
                name: "FK_FavoriteVehicleApplicationUsers_AspNetUsers_ApplicationUserId",
                table: "FavoriteVehicleApplicationUsers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteVehicleApplicationUsers_Vehicles_VehicleId",
                table: "FavoriteVehicleApplicationUsers",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteVehicleApplicationUsers_AspNetUsers_ApplicationUserId",
                table: "FavoriteVehicleApplicationUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteVehicleApplicationUsers_Vehicles_VehicleId",
                table: "FavoriteVehicleApplicationUsers");

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

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteVehicleApplicationUsers_AspNetUsers_ApplicationUserId",
                table: "FavoriteVehicleApplicationUsers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteVehicleApplicationUsers_Vehicles_VehicleId",
                table: "FavoriteVehicleApplicationUsers",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
