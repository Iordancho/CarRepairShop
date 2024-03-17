using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRepairShop.Infrastructure.Migrations
{
    public partial class RepaiShopsSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RepairShops",
                columns: new[] { "Id", "Address", "OwnerId" },
                values: new object[] { 1, "23 G.S. Rakovski Street, Sofia", "a3d9b176-7ae8-4451-b3f9-6990b0677407" });

            migrationBuilder.InsertData(
                table: "RepairShops",
                columns: new[] { "Id", "Address", "OwnerId" },
                values: new object[] { 2, "37 Vasil Levski Street, Plovdiv", "a3d9b176-7ae8-4451-b3f9-6990b0677407" });

            migrationBuilder.InsertData(
                table: "RepairShops",
                columns: new[] { "Id", "Address", "OwnerId" },
                values: new object[] { 3, "82 Khan Krum Street, Burgas", "a3d9b176-7ae8-4451-b3f9-6990b0677407" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RepairShops",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RepairShops",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RepairShops",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
