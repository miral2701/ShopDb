﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBService.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address {  get; set; }

        public List<OrderLine> OrderLines { get; set; } = new();
    }
}
