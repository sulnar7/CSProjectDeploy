using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClarieTheme.Models
{
    public class Contact : BaseEntity
    {
        public string Map { get; set; }
        public int Phone { get; set; }
        [StringLength(1000)]
        public string Email { get; set; }
        [StringLength(2000)]
        public string Address { get; set; }
    }
}
