using CarRepairShop.Core.Contracts;
using CarRepairShop.Core.Models;
using CarRepairShop.Infrastructure.Data.Common;
using CarRepairShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRepairShop.Core.Services
{
    public class RepairShopService : IRepairShopService
    {
        private readonly IRepository repository;

        public RepairShopService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<RepairShopViewModel>> AllRepairShopsAsync()
        {
            return await repository
                .AllReadOnly<RepairShop>()
                .Select(r => new RepairShopViewModel 
                {
                    Id = r.Id,
                    Address = r.Address,
                    ImageUrl = r.ImageUrl,
                })
                .ToListAsync();
        }
    }
}
