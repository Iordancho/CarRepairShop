namespace CarRepairShop.Infrastructure.Data.Models
{
    public class CarMake
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public IList<CarModel> CarModels { get; set; } = new List<CarModel>();
    }
}
