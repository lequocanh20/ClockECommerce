using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace clockECommerce.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public List<Order> Orders { get; set; }
    }
}
