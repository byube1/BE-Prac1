﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIMongoDB.Models
{
    public class Cart
    {
        public string IdProduct { get; set; }
        public string ProductName { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
    }
}