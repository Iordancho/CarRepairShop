using Microsoft.AspNetCore.Identity;

namespace CarRepairShop.Infrastructure.Data.Models
{
    public class RepairShop
    {
        public int Id { get; set; }

        public string Address { get; set; } = string.Empty;

        public string OwnerId { get; set; } = string.Empty;

        public IdentityUser Owner { get; set; } = null!;

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
