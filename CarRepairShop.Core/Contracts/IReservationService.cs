using CarRepairShop.Core.Models;
using CarRepairShop.Infrastructure.Data.Models;

namespace CarRepairShop.Core.Contracts
{
    public interface IReservationService
    {
        Task<IEnumerable<CarReservationViewModel>> GetUserCars(string userId);
        Task<IEnumerable<ServiceTypeReservationViewModel>> GetServiceTypes();
        Task<bool> IsDateAndTimeAvailable(DateTime reservationDateTime);
        Task AddAsync(ReservationWithIdFormViewModel model, DateTime reservationDateAndTime);
        Task<IEnumerable<ReservationStatusViewModel>> GetAllCarReservations(int id);
        Task<Car> CarExists(int id);
        Task<ReservationCancelViewModel?> FindReservationById(int id);
        Task RemoveReservationAsync(int id);

    }
}
