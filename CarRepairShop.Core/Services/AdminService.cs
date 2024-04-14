using CarRepairShop.Core.Contracts;
using CarRepairShop.Core.Models.Admin;
using CarRepairShop.Core.Models.Car;
using CarRepairShop.Core.Models.Reservation;
using CarRepairShop.Infrastructure.Data;
using CarRepairShop.Infrastructure.Data.Common;
using CarRepairShop.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CarRepairShop.Core.Services
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IRepository repository;

        public AdminService(IRepository _repository, UserManager<IdentityUser> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            repository = _repository;
            userManager = _userManager;
            roleManager = _roleManager;
        }

        public async Task AddRole(AddRoleToUserFormModel model, IdentityUser userName)
        {
            string roleName = model.RoleName;
            if (!await roleManager.RoleExistsAsync(roleName))
                await roleManager.CreateAsync(new IdentityRole(roleName));

            await userManager.AddToRoleAsync(userName, roleName);
        }


        public async Task<IEnumerable<CarViewModel>> AllCarsAdminAsync()
        {
            return await repository
                .AllReadOnly<Car>()
                .Select(c => new CarViewModel()
                {
                    Id = c.Id,
                    Make = c.Make.Name,
                    Model = c.Model,
                    VIN = c.VIN,
                    ProductionDate = c.ProductionDate.ToString(DataConstants.DateFormat),
                    OwnerName = c.Owner.UserName
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ReservationsViewModel>> AllReservationsAdminAsync()
        {
            return await repository
                   .AllReadOnly<Reservation>()
                   .Select(r => new ReservationsViewModel()
                   {
                       Id = r.Id,
                       Description = r.Description,
                       ReservationDateTime = r.ReservationDateTime.ToString(DataConstants.DateFormat),
                       RepairShopLocation = r.RepairShop.Address,
                       ServiceType = r.ServiceType.Name,
                       StatusId = r.StatusId,
                       OwnerName = r.Car.Owner.UserName
                   })
                   .ToListAsync();
        }

        public async Task<IEnumerable<UserWithRolesViewModel>> AllUsersAdminAsync()
        {
            List<UserWithRolesViewModel> usersWithRoles = new List<UserWithRolesViewModel>();

            var users = await userManager.Users.ToListAsync();

            foreach (var user in users)
            {
                
                var roles = await userManager.GetRolesAsync(user);

                var userWithRoles = new UserWithRolesViewModel
                {
                    Email = user.Email,
                    Roles = roles
                };

                usersWithRoles.Add(userWithRoles);
            }

            return usersWithRoles;
        }
    }
}
