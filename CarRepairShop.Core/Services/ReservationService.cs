using CarRepairShop.Core.Contracts;
using CarRepairShop.Core.Models;
using CarRepairShop.Infrastructure.Data;
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

        public async Task AddAsync(ReservationWithIdFormViewModel model, DateTime reservationDateAndTime)
        {
            Reservation reservation = new Reservation()
            {
                Description = model.Description,
                CarId = model.CarId,
                ServiceTypeId = model.ServiceTypeId,
                ReservationDateTime = reservationDateAndTime,
                StatusId = 1,
                RepairShopId = model.Id
            };

            await repository.AddAsync(reservation);
            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ReservationStatusViewModel>> GetAllCarReservations(int id)
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
                    .Where(r => r.StatusId == status.Id && r.CarId == id)
                    .Select(r => new ReservationsViewModel()
                    {
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

        public async Task<IEnumerable<CarReservationViewModel>> GetUserCars(string userId)
        {
            return await repository
                .AllReadOnly<Car>()
                .Where(c => c.OwnerId == userId)
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

        public async Task<bool> IsDateAndTimeAvailable(DateTime reservationDateTime)
        {
            if(repository.AllReadOnly<Reservation>().Any(r => r.ReservationDateTime == reservationDateTime))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> CarExists(int id)
        {
            var car = await repository
                .AllReadOnly<Car>()
                .FirstOrDefaultAsync(c => c.Id == id);

            if(car == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<ReservationCancelViewModel?> FindReservationById(int id)
        {
            var reservation = await repository
                .All<Reservation>()
                .Where(r => r.Id == id)
                .Select(r => new ReservationCancelViewModel()
                {
                    Id = r.Id,
                    Description = r.Description,
                    Date = r.ReservationDateTime.ToString(DataConstants.DateFormat),
                    ServiceType = r.ServiceType.Name
                })
                .FirstOrDefaultAsync();

            return reservation;
        }
    }
}
