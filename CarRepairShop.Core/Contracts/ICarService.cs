using CarRepairShop.Core.Models;
using CarRepairShop.Infrastructure.Data.Common;
using CarRepairShop.Infrastructure.Data.Models;


namespace CarRepairShop.Core.Contracts
{
    public interface ICarService
    {
        Task<IEnumerable<MakeFormViewModel>> GetMakes();
        Task AddAsync(CarFormViewModel model, DateTime productionDate, string userId);
        Task<IEnumerable<CarViewModel>> AllCarsAsync(string userId);
        Task<CarDeleteViewModel?> FindCarById(int id);
        Task RemoveCarReservationsAsync(int id);
        Task RemoveCarAsync(int id);
    }
}
