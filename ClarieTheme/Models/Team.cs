using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClarieTheme.Models
{
    public class Team : BaseEntity
    {
        [StringLength(800)]
        public string Image { get; set; }
        [StringLength(1000)]
        public string Fullname { get; set; }
        [StringLength(1000)]
        public string Position { get; set; }
    }
}