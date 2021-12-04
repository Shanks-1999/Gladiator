using System;
using System.Collections.Generic;

#nullable disable

namespace Gladiator.Models
{
    public partial class Premium
    {
        public string VehicleType { get; set; }
        public string VehicleModel { get; set; }
        public long PremiumAmount { get; set; }
    }
}
