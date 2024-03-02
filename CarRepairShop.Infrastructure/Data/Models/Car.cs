using Microsoft.AspNetCore.Identity;

namespace CarRepairShop.Infrastructure.Data.Models
{
    public class Car
    {
        public int Id { get; set; }

        public int MakeId { get; set; }

        public CarMake Make { get; set; } = null!;

        public int ModelId { get; set; }

        public CarModel Model { get; set; } = null!;

        public DateTime Year { get; set; }

        public string VIN { get; set; } = string.Empty;

        public string OwnerId { get; set; } = string.Empty;

        public IdentityUser Owner { get; set; } = null!;

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
