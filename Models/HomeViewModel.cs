using clockECommerce.ViewModels.Catalog.Categories;
using clockECommerce.ViewModels.Catalog.Products;
using System.Collections.Generic;

namespace clockECommerce.WebApp.Models
{
    public class HomeViewModel
    {
        public List<ProductViewModel> FeaturedProducts { get; set; }

        public List<ProductViewModel> LatestProducts { get; set; }

        public List<CategoryViewModel> Categories { get; set; }
    }
}
