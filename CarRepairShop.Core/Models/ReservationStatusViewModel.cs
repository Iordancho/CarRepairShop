namespace CarRepairShop.Core.Models
{
    public class ReservationStatusViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public IEnumerable<AllCarReservationsViewModel> CarReservations { get; set; } = new List<AllCarReservationsViewModel>();
    }
}
