using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClarieTheme.Models
{
    public class Slider : BaseEntity
    {
        [StringLength(800)]
        public string MainTitle { get; set; }
        [StringLength(800)]
        public string Subtitle { get; set; }
        [StringLength(800)]
        public string Image { get; set; }
    }
}
