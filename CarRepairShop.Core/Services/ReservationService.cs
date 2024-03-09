using CarRepairShop.Core.Contracts;
using CarRepairShop.Infrastructure.Data.Common;

namespace CarRepairShop.Core.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IRepository repository;

        public ReservationService(IRepository _repository)
        {
            repository = _repository;
        }
    }
}
