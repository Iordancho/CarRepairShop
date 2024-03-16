using CarRepairShop.Core.Models;
using CarRepairShop.Infrastructure.Data.Common;


namespace CarRepairShop.Core.Contracts
{
    public interface ICarService
    {
        Task<IEnumerable<MakeFormViewModel>> GetMakes();
        Task AddAsync(CarFormViewModel model, DateTime productionDate, string userId);
        Task<IEnumerable<CarViewModel>> AllCarsAsync();
    }
}
