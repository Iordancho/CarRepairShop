using CarRepairShop.Core.Contracts;
using CarRepairShop.Infrastructure.Data.Common;

namespace CarRepairShop.Core.Services
{
    public class CarService : ICarService
    {
        private readonly IRepository repository;

        public CarService(IRepository _repository)
        {
            repository = _repository;
        }
    }
}
