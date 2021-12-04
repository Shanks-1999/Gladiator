using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gladiator.ViewModel
{
    public class Login_VM
    {
        [Key]
        public long CustomerId { get; set; }
        public string Email { get; set; }
    }
}
