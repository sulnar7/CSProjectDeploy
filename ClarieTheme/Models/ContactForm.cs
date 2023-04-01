using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClarieTheme.Models
{
    public class ContactForm : BaseEntity
    {
        [StringLength(1000)]
        public string Name { get; set; }
        [StringLength(1000)]
        public string Email { get; set; }
        public int Phone { get; set; }
        [StringLength(2000)]
        public string Message { get; set; }
    }
}