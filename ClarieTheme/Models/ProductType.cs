using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClarieTheme.Models
{
    public class ProductType : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int TypeId { get; set; }
        public Type Type { get; set; }
    }
}