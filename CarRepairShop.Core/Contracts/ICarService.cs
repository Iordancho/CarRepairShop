using CarRepairShop.Core.Models;
using CarRepairShop.Infrastructure.Data.Common;


namespace CarRepairShop.Core.Contracts
{
    public interface ICarService
    {
        public Task<IEnumerable<MakeFormViewModel>> GetMakes();
        public Task AddAsync(CarFormViewModel model, DateTime productionDate, string userId);
    }
}
