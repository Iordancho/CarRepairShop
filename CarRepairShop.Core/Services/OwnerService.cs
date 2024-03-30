using CarRepairShop.Core.Contracts;
using CarRepairShop.Core.Models;
using CarRepairShop.Infrastructure.Data;
using CarRepairShop.Infrastructure.Data.Common;
using CarRepairShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRepairShop.Core.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IRepository repository;

        public OwnerService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<ReservationsViewModel>> AllRepairShopReservations(int id)
        {
            var reservations = await repository
                    .AllReadOnly<Reservation>()
                    .Where(r => r.RepairShopId == id)
                    .Select(r => new ReservationsViewModel()
                    {
                        Id = r.Id,
                        Description = r.Description,
                        ReservationDateTime = r.ReservationDateTime.ToString(DataConstants.DateFormat),
                        RepairShopLocation = r.RepairShop.Address,
                        ServiceType = r.ServiceType.Name
                    })
                    .ToListAsync();

            return reservations;
        }

        public async Task<bool> RepairShopExists(int id)
        {
            var car = await repository
                .AllReadOnly<RepairShop>()
                .FirstOrDefaultAsync(rp => rp.Id == id);

            if (car == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
