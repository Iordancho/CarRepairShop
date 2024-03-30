using CarRepairShop.Core.Models;

namespace CarRepairShop.Core.Contracts
{
    public interface IOwnerService
    {
        Task<IEnumerable<ReservationsViewModel>> AllRepairShopReservations(int id);
        Task<bool> RepairShopExists(int id);
    }
}
