using CarRepairShop.Core.Models.Reservation;
using CarRepairShop.Infrastructure.Data.Models;

namespace CarRepairShop.Core.Contracts
{
    public interface IOwnerService
    {
        Task<IEnumerable<ReservationStatusViewModel>> AllRepairShopReservations(int id);
        Task<bool> RepairShopExists(int id);
        Task<Reservation> FindReservationById(int id);
        Task FinishService(int id);
    }
}
