﻿namespace CarRepairShop.Core.Models.Car
{
    public class CarDeleteViewModel
    {
        public int Id { get; set; }
        public string MakeAndModel { get; set; } = string.Empty;
        public string OwnerId { get; set; } = string.Empty;
    }
}
