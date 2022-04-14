using System;
using System.Collections.Generic;

#nullable disable

namespace VehicleShowroom.Api.Models
{
    public partial class Showroom
    {
        public int ShowroomId { get; set; }
        public string Name { get; set; }
        public int? DealerId { get; set; }
        public string OwnerName { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? Pincode { get; set; }

        public virtual Dealer Dealer { get; set; }
    }
}
