using System;
using System.Collections.Generic;

#nullable disable

namespace Gladiator.Models
{
    public partial class Claim
    {
        public long ClaimNo { get; set; }
        public long PolicyNo { get; set; }
        public string ReasonForClaim { get; set; }
        public DateTime ClaimDate { get; set; }
        public string Approval { get; set; }

        public virtual Policy PolicyNoNavigation { get; set; }
        public virtual ClaimAmount ReasonForClaimNavigation { get; set; }
    }
}
