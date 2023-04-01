using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClarieTheme.Models
{
    public class Type : BaseEntity
    {
        [StringLength(2000)]
        public string Name { get; set; }
        public List<ProductType> ProductTypes { get; set; }
    }
}
