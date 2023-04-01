﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClarieTheme.ViewModels.Basket
{
    public class BasketVM
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
    }
}
