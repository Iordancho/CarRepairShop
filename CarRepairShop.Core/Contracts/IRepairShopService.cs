using CarRepairShop.Core.Models.RepairShop;

namespace CarRepairShop.Core.Contracts
{
    public interface IRepairShopService
    {
        Task<IEnumerable<RepairShopViewModel>> AllRepairShopsAsync();
    }
}
