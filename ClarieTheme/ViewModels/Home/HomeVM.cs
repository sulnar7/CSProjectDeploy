using ClarieTheme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClarieTheme.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Product> Products{ get; set; }
        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }

    }
}
