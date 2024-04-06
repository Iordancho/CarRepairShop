using CarRepairShop.Core.Contracts;
using CarRepairShop.Core.Models;
using CarRepairShop.Infrastructure.Data.Common;
using CarRepairShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRepairShop.Core.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IRepository repository;

        public StatisticService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<RepairShopStatisticsViewModel> TotalAsync()
        {
            int totalReservations = await repository
                .AllReadOnly<Reservation>()
                .CountAsync();

            return new RepairShopStatisticsViewModel { TotalReservations = totalReservations };
        }
    }
}
