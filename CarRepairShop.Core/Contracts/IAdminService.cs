using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRepairShop.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace CarRepairShop.Core.Contracts
{
    public interface IAdminService
    {
        Task<IEnumerable<CarViewModel>> AllCarsAdminAsync();
        Task<IEnumerable<ReservationsViewModel>> AllReservationsAdminAsync();
        Task<IEnumerable<UserWithRolesViewModel>> AllUsersAdminAsync();
    }
}
