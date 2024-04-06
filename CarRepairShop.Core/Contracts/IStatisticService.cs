using CarRepairShop.Core.Models;

namespace CarRepairShop.Core.Contracts
{
    public interface IStatisticService
    {
        Task<RepairShopStatisticsViewModel> TotalAsync();
    }
}
