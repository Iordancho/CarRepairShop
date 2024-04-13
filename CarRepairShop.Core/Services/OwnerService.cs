using CarRepairShop.Core.Contracts;
using CarRepairShop.Core.Models;
using CarRepairShop.Core.Models.Reservation;
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

        public async Task<IEnumerable<ReservationStatusViewModel>> AllRepairShopReservations(int id)
        {

            var statuses = await repository
                .AllReadOnly<ReservationStatus>()
                .Select(s => new ReservationStatusViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                })
                .ToListAsync();

            foreach (var status in statuses)
            {
                status.CarReservations = await repository
                    .AllReadOnly<Reservation>()
                    .Where(r => r.StatusId == status.Id && r.RepairShopId == id)
                    .Select(r => new ReservationsViewModel()
                    {
                        Id = r.Id,
                        Description = r.Description,
                        ReservationDateTime = r.ReservationDateTime.ToString(DataConstants.DateFormat),
                        RepairShopLocation = r.RepairShop.Address,
                        ServiceType = r.ServiceType.Name,
                        StatusId = r.StatusId
                    })
                    .ToListAsync();
            }

            return statuses;
        }
        public async Task FinishService(int id)
        {
            var reservation = await repository
                .All<Reservation>()
                .FirstOrDefaultAsync(r => r.Id == id);

            reservation.StatusId = 2;
            await repository.SaveChangesAsync();
        }

        public async Task<bool> RepairShopExists(int id)
        {
            var repairShop = await repository
                .AllReadOnly<RepairShop>()
                .FirstOrDefaultAsync(rp => rp.Id == id);

            if (repairShop == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<Reservation?> FindReservationById(int id)
        {
            var reservation = await repository
                .AllReadOnly<Reservation>()
                .FirstOrDefaultAsync(r => r.Id == id);

            return reservation;
        }
    }
}
