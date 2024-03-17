using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRepairShop.Infrastructure.Migrations
{
    public partial class addedImageUrlToRepairShopAndSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "RepairShops",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "RepairShops",
                columns: new[] { "Id", "Address", "ImageUrl", "OwnerId" },
                values: new object[] { 1, "23 G.S. Rakovski Street, Sofia", "https://t4.ftcdn.net/jpg/05/32/90/47/360_F_532904710_cl1gmPtUVGwtiYk10cQlmdQPqaFIlmuD.jpg", "a3d9b176-7ae8-4451-b3f9-6990b0677407" });

            migrationBuilder.InsertData(
                table: "RepairShops",
                columns: new[] { "Id", "Address", "ImageUrl", "OwnerId" },
                values: new object[] { 2, "37 Vasil Levski Street, Plovdiv", "https://media.istockphoto.com/id/147255060/photo/automobiles-serum-station.jpg?s=612x612&w=0&k=20&c=svpKwYykZuAqpg8Pn_qBQBfLLA1d21vTl2Tswr9DZQs=", "a3d9b176-7ae8-4451-b3f9-6990b0677407" });

            migrationBuilder.InsertData(
                table: "RepairShops",
                columns: new[] { "Id", "Address", "ImageUrl", "OwnerId" },
                values: new object[] { 3, "82 Khan Krum Street, Burgas", "https://pictures.dealer.com/l/lithiamotors11/1802/c99cb8a036699f3bcd5cd434df53c93cx.jpg?impolicy=downsize&w=568", "a3d9b176-7ae8-4451-b3f9-6990b0677407" });
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

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "RepairShops");
        }
    }
}
