using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRepairShop.Infrastructure.Migrations
{
    public partial class ProductionDateChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Cars",
                newName: "ProductionDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductionDate",
                table: "Cars",
                newName: "Year");
        }
    }
}
