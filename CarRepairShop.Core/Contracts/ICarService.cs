using CarRepairShop.Core.Models;


namespace CarRepairShop.Core.Contracts
{
    public interface ICarService
    {
        Task<IEnumerable<MakeFormViewModel>> GetMakes();
        Task AddAsync(CarFormViewModel model, DateTime productionDate, string userId);
        Task<IEnumerable<CarViewModel>> AllCarsAsync(string userId, string? searchTerm = null);
        Task<CarDeleteViewModel?> FindCarById(int id);
        Task RemoveCarReservationsAsync(int id);
        Task RemoveCarAsync(int id);
    }
}
