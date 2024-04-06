using CarRepairShop.Core.Services;
using CarRepairShop.Infrastructure.Data;
using CarRepairShop.Infrastructure.Data.Common;
using CarRepairShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRepairShop.UnitTests
{
    [TestFixture]
    public class RepairShopServiceTests
    {
        private RepairShopService repairShopService;
        private DbContextOptions<CarRepairShopDbContext> options;

        [OneTimeSetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<CarRepairShopDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var dbContext = new CarRepairShopDbContext(options);
            repairShopService = new RepairShopService(new Repository(dbContext));
        }

        [Test]
        public async Task AllRepairShopsAsync_ReturnsRepairShopViewModels()
        {
            // Arrange
            var repairShops = new List<RepairShop>
        {
            new RepairShop { Id = 3, Address = "123 Main St", ImageUrl = "image1.jpg" },
            new RepairShop { Id = 4, Address = "456 Elm St", ImageUrl = "image2.jpg" },
        };

            using (var context = new CarRepairShopDbContext(options))
            {
                context.RepairShops.AddRange(repairShops);
                context.SaveChanges();
            }

            // Act
            var result = await repairShopService.AllRepairShopsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(4, result.Count());

            var repairShop1 = result.FirstOrDefault(r => r.Id == 3);
            Assert.NotNull(repairShop1);
            Assert.AreEqual("123 Main St", repairShop1.Address);
            Assert.AreEqual("image1.jpg", repairShop1.ImageUrl);

            var repairShop2 = result.FirstOrDefault(r => r.Id == 4);
            Assert.NotNull(repairShop2);
            Assert.AreEqual("456 Elm St", repairShop2.Address);
            Assert.AreEqual("image2.jpg", repairShop2.ImageUrl);
        }
    }
}
