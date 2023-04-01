using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClarieTheme.Models
{
    public class Subscribe : BaseEntity
    {
        [StringLength(1000)]
        public string Email { get; set; }
    }
}