using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlikteMiniDemo.Domain.Entities
{
    public class Basket
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; } = null!;
        public ICollection<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
    }
}
