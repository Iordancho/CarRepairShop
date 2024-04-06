using CarRepairShop.Core.Models;

namespace CarRepairShop.Core.Contracts
{
    public interface IRepairShopService
    {
        Task<IEnumerable<RepairShopViewModel>> AllRepairShopsAsync();
    }
}
