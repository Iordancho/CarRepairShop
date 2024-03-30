﻿using CarRepairShop.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarRepairShop.Core.Models
{
    public class AllCarReservationsViewModel
    {
        public string Description { get; set; } = string.Empty;

        public string StatusId { get; set; } = string.Empty;

        public string ReservationDateTime { get; set; } = string.Empty;

        public string RepairShopLocation { get; set; } = string.Empty;

        public string ServiceType { get; set; } = string.Empty;
    }
}
