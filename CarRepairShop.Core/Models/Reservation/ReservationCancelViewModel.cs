﻿namespace CarRepairShop.Core.Models.Reservation
{
    public class ReservationCancelViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string ServiceType { get; set; } = string.Empty;
        public string OwnerId { get; set; } = string.Empty;
        public int StatusId { get; set; }
    }
}
