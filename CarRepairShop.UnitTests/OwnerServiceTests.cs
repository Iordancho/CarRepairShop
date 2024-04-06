using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRepairShop.Core.Services;
using CarRepairShop.Infrastructure.Data.Common;
using CarRepairShop.Infrastructure.Data;
using CarRepairShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using CarRepairShop.Core.Contracts;

namespace CarRepairShop.UnitTests
{
    [TestFixture]
    public class OwnerServiceTests
    {
        private OwnerService ownerService;
        private DbContextOptions<CarRepairShopDbContext> options;

        [OneTimeSetUp]
        public void Setup()
        {
            
            options = new DbContextOptionsBuilder<CarRepairShopDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            
            var dbContext = new CarRepairShopDbContext(options);
            ownerService = new OwnerService(new Repository(dbContext));
        }

        [Test]
        public async Task FinishService_UpdatesReservationStatusToFinished()
        {
            // Arrange
            var reservationId = 6;
            var reservation = new Reservation { Id = reservationId, StatusId = 1 }; 

            using (var context = new CarRepairShopDbContext(options))
            {
                context.Reservations.Add(reservation);
                context.SaveChanges();
            }

            // Act
            await ownerService.FinishService(reservationId);

            // Assert
            using (var context = new CarRepairShopDbContext(options))
            {
                var updatedReservation = await context.Reservations.FindAsync(reservationId);
                Assert.NotNull(updatedReservation);
                Assert.AreEqual(2, updatedReservation.StatusId); 
            }
        }

        [Test]
        public async Task RepairShopExists_WithExistingId_ReturnsTrue()
        {
            // Arrange
            var repairShopId = 2;
            var repairShop = new RepairShop { Id = repairShopId, ImageUrl="imgurl" };

            using (var context = new CarRepairShopDbContext(options))
            {
                context.RepairShops.Add(repairShop);
                context.SaveChanges();
            }

            // Act
            var shopExists = await ownerService.RepairShopExists(repairShopId);

            // Assert
            Assert.True(shopExists);
        }

        [Test]
        public async Task RepairShopExists_WithNonExistingId_ReturnsFalse()
        {
            // Arrange
            var nonExistingRepairShopId = -1;

            // Act
            var shopExists = await ownerService.RepairShopExists(nonExistingRepairShopId);

            // Assert
            Assert.False(shopExists);
        }

        [Test]
        public async Task FindReservationById_ReturnsReservation()
        {
            // Arrange
            var reservationId = 7;
            var reservation = new Reservation { Id = reservationId };

            using (var context = new CarRepairShopDbContext(options))
            {
                context.Reservations.Add(reservation);
                context.SaveChanges();
            }

            // Act
            var foundReservation = await ownerService.FindReservationById(reservationId);

            // Assert
            Assert.NotNull(foundReservation);
            Assert.AreEqual(reservationId, foundReservation.Id);
        }

        [Test]
        public async Task FindReservationById_ReturnsNullForNonExistingId()
        {
            // Arrange
            var nonExistingReservationId = -1;

            // Act
            var foundReservation = await ownerService.FindReservationById(nonExistingReservationId);

            // Assert
            Assert.Null(foundReservation);
        }

       
    }
}
