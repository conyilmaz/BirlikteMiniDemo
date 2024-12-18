﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlikteMiniDemo.Domain.Entities
{
    public class BasketItem
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }

        public Guid BasketId { get; set; }
        public Guid ProductId { get; set; }

        public Basket Basket { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}
