using CarRepairShop.Core.Contracts;
using CarRepairShop.Core.Models;
using CarRepairShop.Infrastructure.Data.Common;
using CarRepairShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRepairShop.Core.Services
{
    public class CarService : ICarService
    {
        private readonly IRepository repository;

        public CarService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<MakeViewModel>> GetMakes()
        {
            return await repository
                .AllReadOnly<CarMake>()
                .Select(cm => new MakeViewModel()
                {
                    Id = cm.Id,
                    Name = cm.Name,
                })
                .ToListAsync();
        }
    }
}
