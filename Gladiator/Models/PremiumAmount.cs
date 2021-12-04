using System;
using System.Collections.Generic;

#nullable disable

namespace Gladiator.Models
{
    public partial class PremiumAmount
    {
        public PremiumAmount()
        {
            Policies = new HashSet<Policy>();
        }

        public string VehicleModel { get; set; }
        public string PlanType { get; set; }
        public int PremiumAmount1 { get; set; }

        public virtual ICollection<Policy> Policies { get; set; }
    }
}
