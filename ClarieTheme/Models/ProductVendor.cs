using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClarieTheme.Models
{
    public class ProductVendor : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
    }
}
