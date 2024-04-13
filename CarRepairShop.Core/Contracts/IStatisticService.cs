using CarRepairShop.Core.Models.RepairShop;

namespace CarRepairShop.Core.Contracts
{
    public interface IStatisticService
    {
        Task<RepairShopStatisticsViewModel> TotalAsync();
    }
}
