using System;
using System.Collections.Generic;

#nullable disable

namespace Gladiator.Models
{
    public partial class Policy
    {
        public Policy()
        {
            Claims = new HashSet<Claim>();
        }

        public long PolicyNo { get; set; }
        public long CustomerId { get; set; }
        public string VehicleType { get; set; }
        public string EngineNo { get; set; }
        public string ChassisNo { get; set; }
        public string VehicleRegistrationNo { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleManufacturer { get; set; }
        public string DrivingLicence { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string PlanDuration { get; set; }
        public long TransactionId { get; set; }
        public DateTime? TransactionDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual PremiumAmount VehicleModelNavigation { get; set; }
        public virtual ICollection<Claim> Claims { get; set; }
    }
}
