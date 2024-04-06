using CarRepairShop.Core.Models;
using CarRepairShop.Core.Services;
using CarRepairShop.Infrastructure.Data;
using CarRepairShop.Infrastructure.Data.Common;
using CarRepairShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CarRepairShop.UnitTests
{
    [TestFixture]
    public class CarServiceTests
    {

        private CarService carService;
        private DbContextOptions<CarRepairShopDbContext> options;

        [OneTimeSetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<CarRepairShopDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var dbContext = new CarRepairShopDbContext(options);
            carService = new CarService(new Repository(dbContext));
        }

        [Test]
        public async Task AddAsync_CallsRepositoryAddAsyncAndSaveChangesAsync()
        {
            var repositoryMock = new Mock<IRepository>();
            var service = new CarService(repositoryMock.Object);
            var model = new CarFormViewModel();
            var productionDate = DateTime.Now;
            var userId = "user123";


            await service.AddAsync(model, productionDate, userId);


            repositoryMock.Verify(x => x.AddAsync<Car>(It.IsAny<Car>()), Times.Once);
            repositoryMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task GetMakes_ReturnsMakeFormViewModelList()
        {
            // Arrange
            using (var context = new CarRepairShopDbContext(options))
            {
                context.CarMakes.Add(new CarMake { Id = 8, Name = "Toyota" });
                context.CarMakes.Add(new CarMake { Id = 9, Name = "Honda" });
                context.SaveChanges();
            }

            // Act
            var result = await carService.GetMakes();

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(9, result.Count());
            
            Assert.AreEqual(1, result.ElementAt(0).Id);
            Assert.AreEqual("Toyota", result.ElementAt(0).Name);

            Assert.AreEqual(2, result.ElementAt(1).Id);
            Assert.AreEqual("Honda", result.ElementAt(1).Name);
        }

        [Test]
        public async Task AllCarsAsync_ReturnsCarsListForUser()
        {
            // Arrange
            string userId = "user1";
            string searchTerm = "Toyota";

            using (var context = new CarRepairShopDbContext(options))
            {
                context.Cars.Add(new Car { Id = 4, Make = new CarMake { Name = "Toyota" }, Model = "Camry", VIN = "1234", ProductionDate = DateTime.Now, OwnerId = userId });
                context.Cars.Add(new Car { Id = 5, Make = new CarMake { Name = "Honda" }, Model = "Civic", VIN = "5678", ProductionDate = DateTime.Now, OwnerId = userId });
                context.SaveChanges();
            }

            // Act
            var result = await carService.AllCarsAsync(userId, searchTerm);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(1, result.Count());

            var carViewModel = result.First();
            Assert.AreEqual("Toyota", carViewModel.Make);
            Assert.AreEqual("Camry", carViewModel.Model);
            Assert.AreEqual("1234", carViewModel.VIN);
        }

        [Test]
        public async Task AllCarsAsync_ReturnsAllCarsForUserWhenNoSearchTermGiven()
        {
            // Arrange
            string userId = "user2";

            using (var context = new CarRepairShopDbContext(options))
            {
                context.Cars.Add(new Car { Id = 6, Make = new CarMake { Name = "Toyota" }, Model = "Corolla", VIN = "ABCD", ProductionDate = DateTime.Now, OwnerId = userId });
                context.Cars.Add(new Car { Id = 7, Make = new CarMake { Name = "Honda" }, Model = "Accord", VIN = "EFGH", ProductionDate = DateTime.Now.AddYears(-3), OwnerId = userId });
                context.SaveChanges();
            }

            // Act
            var result = await carService.AllCarsAsync(userId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public async Task FindCarById_ReturnsCarDeleteViewModel()
        {
            // Arrange
            int carIdToFind = 10;

            using (var context = new CarRepairShopDbContext(options))
            {
                context.Cars.Add(new Car { Id = carIdToFind, Make = new CarMake { Name = "Toyota" }, Model = "Camry", OwnerId = "user1" });
                context.SaveChanges();
            }

            // Act
            var result = await carService.FindCarById(carIdToFind);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(carIdToFind, result.Id);
            Assert.AreEqual("Toyota Camry", result.MakeAndModel);
            Assert.AreEqual("user1", result.OwnerId);
        }

        [Test]
        public async Task FindCarById_ReturnsNullForNonExistingCarId()
        {
            // Arrange
            int nonExistingCarId = -1;

            // Act
            var result = await carService.FindCarById(nonExistingCarId);

            // Assert
            Assert.Null(result);
        }

        [Test]
        public async Task RemoveCarReservationsAsync_RemovesReservationsForCar()
        {
            // Arrange
            int carId = 1;

            using (var context = new CarRepairShopDbContext(options))
            {
                context.Reservations.Add(new Reservation { Id = 3, CarId = carId});
                context.Reservations.Add(new Reservation { Id = 4, CarId = carId});
                context.SaveChanges();
            }

            // Act
            await carService.RemoveCarReservationsAsync(carId);

            // Assert
            using (var context = new CarRepairShopDbContext(options))
            {
                var reservations = await context.Reservations.Where(r => r.CarId == carId).ToListAsync();
                Assert.IsEmpty(reservations);
            }
        }

        [Test]
        public async Task RemoveCarReservationsAsync_DoesNotRemoveReservationsForInactiveCar()
        {
            // Arrange
            int inactiveCarId = -1;

            using (var context = new CarRepairShopDbContext(options))
            {
                context.Reservations.Add(new Reservation { Id = 5, CarId = inactiveCarId});
                context.SaveChanges();
            }

            // Act
            await carService.RemoveCarReservationsAsync(inactiveCarId);

            // Assert
            using (var context = new CarRepairShopDbContext(options))
            {
                var reservations = await context.Reservations.Where(r => r.CarId == inactiveCarId).ToListAsync();
                Assert.IsEmpty(reservations);
            }
        }


    }
}
