using System;
using System.Collections.Generic;

#nullable disable

namespace VehicleShowroom.Api.Models
{
    public partial class Vehicle
    {
        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        public string VehicleModel { get; set; }
        public int? DealerId { get; set; }
        public decimal Cost { get; set; }
        public int TotalStock { get; set; }
        public string Description { get; set; }
        public int? Rating { get; set; }

        public virtual Dealer Dealer { get; set; }
    }
}
