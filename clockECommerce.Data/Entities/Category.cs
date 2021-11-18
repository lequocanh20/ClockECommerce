using System;
using System.Collections.Generic;
using System.Text;

namespace clockECommerce.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
