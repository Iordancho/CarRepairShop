using CarRepairShop.Core.Contracts;
using CarRepairShop.Core.Models;
using CarRepairShop.Infrastructure.Data.Common;
using CarRepairShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

using CarRepairShop;


namespace CarRepairShop.Core.Services
{
    public class CarService : ICarService
    {
        private readonly IRepository repository;

        public CarService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task AddAsync(CarFormViewModel model, DateTime productionDate, string userId)
        {
            Car car = new Car()
            {
                MakeId = model.MakeId,
                Model = model.Model,
                VIN = model.VIN,
                ProductionDate = productionDate,
                OwnerId = userId,
            };

            await repository.AddAsync<Car>(car);
            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<MakeFormViewModel>> GetMakes()
        {
            return await repository
                .AllReadOnly<CarMake>()
                .Select(cm => new MakeFormViewModel()
                {
                    Id = cm.Id,
                    Name = cm.Name,
                })
                .ToListAsync();
        }
    }
}
