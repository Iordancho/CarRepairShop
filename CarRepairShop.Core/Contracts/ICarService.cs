using CarRepairShop.Core.Models;
using CarRepairShop.Infrastructure.Data.Common;

namespace CarRepairShop.Core.Contracts
{
    public interface ICarService
    {
        public Task<IEnumerable<MakeViewModel>> GetMakes();


    }
}
