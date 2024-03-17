using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRepairShop.Infrastructure.Migrations
{
    public partial class ReservationStatusSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ReservationStatus",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Due" });

            migrationBuilder.InsertData(
                table: "ReservationStatus",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Past" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ReservationStatus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ReservationStatus",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
