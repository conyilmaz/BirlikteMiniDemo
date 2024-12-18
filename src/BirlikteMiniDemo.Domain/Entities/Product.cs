using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlikteMiniDemo.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }

        public Category Category { get; set; } = null!;
        public ICollection<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
    }
}
