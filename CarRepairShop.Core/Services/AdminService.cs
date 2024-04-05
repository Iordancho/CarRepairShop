using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRepairShop.Core.Contracts;
using CarRepairShop.Core.Models;
using CarRepairShop.Infrastructure.Data.Common;
using CarRepairShop.Infrastructure.Data.Models;
using CarRepairShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CarRepairShop.Core.Services
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IRepository repository;

        public AdminService(IRepository _repository, UserManager<IdentityUser> _userManager)
        {
            repository = _repository;
            userManager = _userManager;
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
