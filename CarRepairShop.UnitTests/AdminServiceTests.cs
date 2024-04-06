using CarRepairShop.Core.Services;
using CarRepairShop.Infrastructure.Data;
using CarRepairShop.Infrastructure.Data.Common;
using CarRepairShop.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CarRepairShop.UnitTests
{
    [TestFixture]
    public class AdminServiceTests
    {
        private AdminService adminService;
        private DbContextOptions<CarRepairShopDbContext> options;
        private UserManager<IdentityUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        private Mock<UserManager<IdentityUser>> mockUserManager;

        [OneTimeSetUp]
        public void Setup()
        {
            // Initialize in-memory database for testing
            options = new DbContextOptionsBuilder<CarRepairShopDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            // Initialize car service with the mock repository
            var dbContext = new CarRepairShopDbContext(options);
            adminService = new AdminService(new Repository(dbContext), userManager, roleManager);
        }

        [Test]
        public async Task AllCarsAdminAsync_ReturnsCarViewModels()
        {
            // Arrange
            var car1 = new Car
            {
                Id = 1,
                Make = new CarMake { Name = "Toyota" },
                Model = "Camry",
                VIN = "123456789",
                ProductionDate = DateTime.UtcNow,
                Owner = new IdentityUser { UserName = "Admin" }
            };
            var car2 = new Car
            {
                Id = 2,
                Make = new CarMake { Name = "Honda" },
                Model = "Accord",
                VIN = "987654321",
                ProductionDate = DateTime.UtcNow,
                Owner = new IdentityUser { UserName = "User" }
            };

            using (var context = new CarRepairShopDbContext(options))
            {
                context.Cars.AddRange(car1, car2);
                context.SaveChanges();
            }

            // Act
            var carViewModels = await adminService.AllCarsAdminAsync();

            // Assert
            Assert.AreEqual(2, carViewModels.Count());
            Assert.That(carViewModels.Any(c => c.Id == 1));
            Assert.That(carViewModels.Any(c => c.Id == 2));
            Assert.That(carViewModels.Any(c => c.Make == "Honda"));
            Assert.That(carViewModels.Any(c => c.Make == "Toyota"));
            Assert.That(carViewModels.Any(c => c.Model == "Accord"));
            Assert.That(carViewModels.Any(c => c.Model == "Camry"));

        }

        [Test]
        public async Task AllReservationsAdminAsync_ReturnsReservationsViewModels()
        {
            // Arrange
            var repairShop = new RepairShop { Id = 1, Address = "123 Main St", ImageUrl="imgurl" };
            var serviceType = new ServiceType { Id = 1, Name = "Oil Change" };
            var car = new Car { Id = 3, Owner = new IdentityUser { UserName = "Admin" }, Model ="325d" };
            var reservation1 = new Reservation
            {
                Id = 1,
                Description = "Regular Maintenance",
                ReservationDateTime = DateTime.UtcNow,
                RepairShop = repairShop,
                ServiceType = serviceType,
                StatusId = 1,
                Car = car
            };
            var reservation2 = new Reservation
            {
                Id = 2,
                Description = "Brake Repair",
                ReservationDateTime = DateTime.UtcNow,
                RepairShop = repairShop,
                ServiceType = serviceType,
                StatusId = 2,
                Car = car
            };

            using (var context = new CarRepairShopDbContext(options))
            {
                context.Reservations.AddRange(reservation1, reservation2); 
                context.SaveChanges();
            }

            // Act
            var reservationsViewModels = await adminService.AllReservationsAdminAsync();

            // Assert
            Assert.AreEqual(2, reservationsViewModels.Count());
            Assert.That(reservationsViewModels.Any(c => c.Id == 1));
            Assert.That(reservationsViewModels.Any(c => c.Id == 2));
            Assert.That(reservationsViewModels.Any(c => c.Description == "Regular Maintenance"));
            Assert.That(reservationsViewModels.Any(c => c.Description == "Brake Repair"));

        }



    }
}
