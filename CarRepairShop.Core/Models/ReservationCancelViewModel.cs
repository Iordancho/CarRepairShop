﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairShop.Core.Models
{
    public class ReservationCancelViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string ServiceType { get; set; } = string.Empty;
    }
}