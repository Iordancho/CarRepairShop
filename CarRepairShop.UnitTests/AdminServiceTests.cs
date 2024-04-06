using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRepairShop.Core.Services;
using CarRepairShop.Infrastructure.Data.Common;
using CarRepairShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CarRepairShop.Core.Contracts;
using CarRepairShop.Infrastructure.Data.Models;
using Moq;
using CarRepairShop.Areas.Admin.Models;
using CarRepairShop.Core.Models;

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

            List<IdentityUser> users = new List<IdentityUser>
            {
                new IdentityUser { Id = "1", Email = "user1@example.com" },
                new IdentityUser { Id = "2", Email = "user2@example.com" }
                // Add more test users as needed
            };

            var userStore = new Mock<IUserStore<IdentityUser>>();
            mockUserManager = new Mock<UserManager<IdentityUser>>(userStore.Object, null, null, null, null, null, null, null, null);

            mockUserManager.Setup(m => m.Users).Returns(users.AsQueryable());

            
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
        }

       

    }
}
