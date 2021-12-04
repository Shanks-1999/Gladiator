using System;
using System.Collections.Generic;

#nullable disable

namespace Gladiator.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Policies = new HashSet<Policy>();
        }

        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }
        public long ContactNo { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public long? Pincode { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Policy> Policies { get; set; }
    }
}
