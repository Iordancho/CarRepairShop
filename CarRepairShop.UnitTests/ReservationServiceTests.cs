using CarRepairShop.Core.Models;
using CarRepairShop.Core.Services;
using CarRepairShop.Infrastructure.Data;
using CarRepairShop.Infrastructure.Data.Common;
using CarRepairShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRepairShop.UnitTests
{
    [TestFixture]
    public class ReservationServiceTests
    {
        private ReservationService reservationService;
        private DbContextOptions<CarRepairShopDbContext> options;

        [OneTimeSetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<CarRepairShopDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var dbContext = new CarRepairShopDbContext(options);
            reservationService = new ReservationService(new Repository(dbContext));
        }

        [Test]
        public async Task AddAsync_AddsReservation()
        {
            // Arrange
            var model = new ReservationWithIdFormViewModel
            {
                Description = "Test reservation",
                CarId = 1,
                ServiceTypeId = 1,
                Id = 1 // RepairShopId
            };

            DateTime reservationDateTime = DateTime.Now;

            // Act
            await reservationService.AddAsync(model, reservationDateTime);

            // Assert
            using (var context = new CarRepairShopDbContext(options))
            {
                var reservation = await context.Reservations.FirstOrDefaultAsync(r => r.Description == "Test reservation");
                Assert.NotNull(reservation);
                Assert.AreEqual(1, reservation.CarId);
                Assert.AreEqual(1, reservation.ServiceTypeId);
                Assert.AreEqual(1, reservation.StatusId);
                Assert.AreEqual(1, reservation.RepairShopId);
                Assert.AreEqual(reservationDateTime, reservation.ReservationDateTime);
            }
        }

        [Test]
        public async Task GetServiceTypes_ReturnsServiceTypesForReservations()
        {
            // Arrange
            var serviceTypes = new List<ServiceType>
        {
            new ServiceType { Id = 2, Name = "Service Type 2" },
            new ServiceType { Id = 3, Name = "Service Type 3" }
        };

            using (var context = new CarRepairShopDbContext(options))
            {
                context.ServiceTypes.AddRange(serviceTypes);
                context.SaveChanges();
            }

            // Act
            var result = await reservationService.GetServiceTypes();

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(3, result.Count());

            foreach (var serviceType in result)
            {
                Assert.NotNull(serviceType);
                Assert.True(!string.IsNullOrEmpty(serviceType.Name));

                // Add additional assertions if needed
            }
        }

        [Test]
        public async Task IsDateAndTimeAvailable_ReturnsAvailability()
        {
            // Arrange
            DateTime existingReservationDateTime = new DateTime(2021, 10, 15, 10, 0, 0);
            DateTime newReservationDateTime = new DateTime(2022, 12, 20, 11, 30, 0);

            var existingReservation = new Reservation { Id = 9, ReservationDateTime = existingReservationDateTime };

            using (var context = new CarRepairShopDbContext(options))
            {
                context.Reservations.Add(existingReservation);
                context.SaveChanges();
            }

            // Act
            var isAvailable = await reservationService.IsDateAndTimeAvailable(newReservationDateTime);

            // Assert
            Assert.True(isAvailable);
        }


        [Test]
        public async Task CarExists_WithNonExistingCarId_ReturnsNull()
        {
            // Arrange
            int nonExistingCarId = -1;

            // Act
            var car = await reservationService.CarExists(nonExistingCarId);

            // Assert
            Assert.Null(car);
        }

        [Test]
        public async Task FindReservationById_WithNonExistingId_ReturnsNull()
        {
            // Arrange
            int nonExistingReservationId = -1;

            // Act
            var reservationVm = await reservationService.FindReservationById(nonExistingReservationId);

            // Assert
            Assert.Null(reservationVm);
        }

        [Test]
        public async Task RemoveReservationAsync_RemovesReservation()
        {
            // Arrange
            var reservationId = 10;
            var reservation = new Reservation { Id = reservationId };

            using (var context = new CarRepairShopDbContext(options))
            {
                context.Reservations.Add(reservation);
                context.SaveChanges();
            }

            // Act
            await reservationService.RemoveReservationAsync(reservationId);

            // Assert
            using (var context = new CarRepairShopDbContext(options))
            {
                var removedReservation = await context.Reservations.FindAsync(reservationId);
                Assert.Null(removedReservation);
            }
        }

        [Test]
        public async Task GetUserCars_ReturnsUserCars()
        {
            // Arrange
            var testUserId = "testUserId";
            var carId = 8;
            var testUserCars = new List<Car>
            {
                new Car { Id = carId, OwnerId = testUserId, Make = new CarMake { Name = "Toyota" }, Model = "Camry" }
            };

            using (var dbContext = new CarRepairShopDbContext(options))
            {
                dbContext.Cars.AddRange(testUserCars);
                dbContext.SaveChanges();
            }

            // Act
            var userCars = await reservationService.GetUserCars(testUserId);

            // Assert
            Assert.IsNotNull(userCars);
            Assert.AreEqual(1, userCars.Count());

            var firstCar = userCars.First();
            Assert.AreEqual(carId, firstCar.Id);
            Assert.AreEqual("Toyota Camry", firstCar.MakeAndModel);
        }
    }
}
