using CarRepairShop.Core.Models;

namespace CarRepairShop.Core.Contracts
{
    public interface IReservationService
    {
        Task<IEnumerable<CarReservationViewModel>> GetUserCars(string userId);
        Task<IEnumerable<ServiceTypeReservationViewModel>> GetServiceTypes();
        Task<bool> IsDateAndTimeAvailable(DateTime reservationDateTime);
        Task AddAsync(ReservationWithIdFormViewModel model, DateTime reservationDateAndTime);
        Task<IEnumerable<ReservationStatusViewModel>> GetAllCarReservations(int id);
        Task<bool> CarExists(int id);
    }
}
