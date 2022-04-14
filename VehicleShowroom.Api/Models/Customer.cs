using System;
using System.Collections.Generic;


namespace VehicleShowroom.Api.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Gender { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? Pincode { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
