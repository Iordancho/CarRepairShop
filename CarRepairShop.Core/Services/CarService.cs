using CarRepairShop.Core.Contracts;
using CarRepairShop.Core.Models;
using CarRepairShop.Infrastructure.Data;
using CarRepairShop.Infrastructure.Data.Common;
using CarRepairShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace CarRepairShop.Core.Services
{
    public class CarService : ICarService
    {
        private readonly IRepository repository;
        private CarRepairShopDbContext data;

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

        public async Task<IEnumerable<CarViewModel>> AllCarsAsync(string userId, string? searchTerm = null)
        {
            var carsToShow = repository
                .AllReadOnly<Car>()
                .Where(c => c.OwnerId == userId);

            if(searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                carsToShow = carsToShow
                    .Where(c => (c.Model.ToLower().Contains(normalizedSearchTerm )||
                                 c.Make.Name.ToLower().Contains(normalizedSearchTerm)));
            }

            return await carsToShow
                .Select(c => new CarViewModel() 
                { 
                    Id = c.Id,
                    Make = c.Make.Name,
                    Model = c.Model,
                    VIN = c.VIN,
                    ProductionDate = c.ProductionDate.ToString(DataConstants.DateFormat)
                })
                .ToListAsync();
        }

        public async Task<CarDeleteViewModel?> FindCarById(int id)
        {
             var car = await repository
                .All<Car>()
                .Where(c => c.Id == id)
                .Select(c => new CarDeleteViewModel()
                {
                    Id = c.Id,
                    MakeAndModel = c.Make.Name + " " + c.Model,
                    OwnerId = c.OwnerId,
                })
                .FirstOrDefaultAsync();

            return car;
        }

        public async Task RemoveCarReservationsAsync(int id)
        {
            var carReservations = await repository
                .All<Reservation>()
                .Where(r => r.CarId == id)
                .ToListAsync();

            await repository.RemoveRangeAsync(carReservations);
            await repository.SaveChangesAsync();
        }

        public async Task RemoveCarAsync(int id)
        {
            var car = await repository
                .All<Car>()
                .FirstOrDefaultAsync(c => c.Id == id);

            await repository.RemoveAsync(car);
            await repository.SaveChangesAsync();
        }
    }
}
