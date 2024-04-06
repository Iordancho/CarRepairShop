using CarRepairShop.Core.Services;
using CarRepairShop.Infrastructure.Data;
using CarRepairShop.Infrastructure.Data.Common;
using CarRepairShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRepairShop.UnitTests
{
    [TestFixture]
    public class StatisticServiceTests
    {
        private StatisticService statisticService;
        private DbContextOptions<CarRepairShopDbContext> options;

        [OneTimeSetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<CarRepairShopDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var dbContext = new CarRepairShopDbContext(options);
            statisticService = new StatisticService(new Repository(dbContext));
        }

        [Test]
        public async Task TotalAsync_ReturnsRepairShopStatisticsViewModel()
        {
            // Arrange
            var reservation1 = new Reservation { Id = 11 };
            var reservation2 = new Reservation { Id = 12 };

            using (var context = new CarRepairShopDbContext(options))
            {
                context.Reservations.AddRange(reservation1, reservation2);
                context.SaveChanges();
            }

            // Act
            var repairShopStatisticsViewModel = await statisticService.TotalAsync();

            // Assert
            Assert.AreEqual(8, repairShopStatisticsViewModel.TotalReservations);
        }
    }
}
