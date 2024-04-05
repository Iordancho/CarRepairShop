using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRepairShop.Core.Contracts;
using CarRepairShop.Core.Models;
using CarRepairShop.Infrastructure.Data.Common;
using CarRepairShop.Infrastructure.Data.Models;
using CarRepairShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CarRepairShop.Core.Services
{
    public class AdminService : IAdminService
    {
        private readonly IRepository repository;

        public AdminService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<CarViewModel>> AllCarsAdminAsync()
        {
            return await repository
                .AllReadOnly<Car>()
                .Select(c => new CarViewModel()
                {
                    Id = c.Id,
                    Make = c.Make.Name,
                    Model = c.Model,
                    VIN = c.VIN,
                    ProductionDate = c.ProductionDate.ToString(DataConstants.DateFormat),
                    OwnerName = c.Owner.UserName
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ReservationsViewModel>> AllReservationsAdminAsync()
        {
            return await repository
                   .AllReadOnly<Reservation>()
                   .Select(r => new ReservationsViewModel()
                   {
                       Id = r.Id,
                       Description = r.Description,
                       ReservationDateTime = r.ReservationDateTime.ToString(DataConstants.DateFormat),
                       RepairShopLocation = r.RepairShop.Address,
                       ServiceType = r.ServiceType.Name,
                       StatusId = r.StatusId,
                       OwnerName = r.Car.Owner.UserName
                   })
                   .ToListAsync();
        }
    }
}
