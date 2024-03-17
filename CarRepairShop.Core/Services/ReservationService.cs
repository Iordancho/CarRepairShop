using CarRepairShop.Core.Contracts;
using CarRepairShop.Core.Models;
using CarRepairShop.Infrastructure.Data.Common;
using CarRepairShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRepairShop.Core.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IRepository repository;

        public ReservationService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<CarReservationViewModel>> GetUserCars(string userId)
        {
            return await repository
                .AllReadOnly<Car>()
                .Select(cm => new CarReservationViewModel()
                {
                    Id = cm.Id,
                    MakeAndModel = cm.Make.Name + " " + cm.Model
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ServiceTypeReservationViewModel>> GetServiceTypes()
        {
            return await repository
                .AllReadOnly<ServiceType>()
                .Select(cm => new ServiceTypeReservationViewModel()
                {
                    Id = cm.Id,
                    Name = cm.Name
                })
                .ToListAsync();
        }
    }
}
