namespace CarRepairShop.Core.Models.RepairShop
{
    public class RepairShopViewModel
    {
        public int Id { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = null!;
    }
}
