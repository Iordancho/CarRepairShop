﻿namespace CarRepairShop.Core.Models.Reservation
{
    public class ReservationStatusViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public IEnumerable<ReservationsViewModel> CarReservations { get; set; } = new List<ReservationsViewModel>();
    }
}
