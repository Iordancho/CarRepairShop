namespace CarRepairShop.Core.Models.Car
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string Model { get; set; } = string.Empty;
        public string Make { get; set; } = string.Empty;
        public string ProductionDate { get; set; } = string.Empty;
        public string VIN { get; set; } = string.Empty;
        public string OwnerName { get; set; } = string.Empty;
    }
}
