using System;
using System.Collections.Generic;

#nullable disable

namespace Gladiator.Models
{
    public partial class ClaimAmount
    {
        public ClaimAmount()
        {
            Claims = new HashSet<Claim>();
        }

        public string ReasonForClaim { get; set; }
        public long Amount { get; set; }

        public virtual ICollection<Claim> Claims { get; set; }
    }
}
