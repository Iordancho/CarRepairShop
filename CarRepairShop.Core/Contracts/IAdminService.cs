using CarRepairShop.Areas.Admin.Models;
using CarRepairShop.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace CarRepairShop.Core.Contracts
{
    public interface IAdminService
    {
        Task<IEnumerable<CarViewModel>> AllCarsAdminAsync();
        Task<IEnumerable<ReservationsViewModel>> AllReservationsAdminAsync();
        Task<IEnumerable<UserWithRolesViewModel>> AllUsersAdminAsync();
        Task AddRole(AddRoleToUserFormModel model, IdentityUser userName);
    }
}
