namespace CarRepairShop.Core.Models.Reservation
{
    public class ReservationsViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public int StatusId { get; set; }

        public string ReservationDateTime { get; set; } = string.Empty;

        public string RepairShopLocation { get; set; } = string.Empty;

        public string ServiceType { get; set; } = string.Empty;

        public string OwnerName { get; set; } = string.Empty;
    }
}
