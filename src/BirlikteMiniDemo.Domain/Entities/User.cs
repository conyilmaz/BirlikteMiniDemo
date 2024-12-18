using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlikteMiniDemo.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? ProfilePhotoUrl { get; set; }

        public Basket? Basket { get; set; }
    }
}
