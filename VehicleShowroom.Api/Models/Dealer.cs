using System;
using System.Collections.Generic;

#nullable disable

namespace VehicleShowroom.Api.Models
{
    public partial class Dealer
    {
        public Dealer()
        {
            Showrooms = new HashSet<Showroom>();
            Vehicles = new HashSet<Vehicle>();
        }

        public int DealerId { get; set; }
        public string DealerName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? Pincode { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Showroom> Showrooms { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
