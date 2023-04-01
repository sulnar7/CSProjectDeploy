using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClarieTheme.Models
{
    public class Product : BaseEntity
    {
        [StringLength(800)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        [StringLength(800)]
        public string Title { get; set; }
        public int Price { get; set; }
        public int OldPrice { get; set; }
        public List<ProductVendor> ProductVendors { get; set; }
        public List<ProductType> ProductTypes { get; set; }

    }
}

