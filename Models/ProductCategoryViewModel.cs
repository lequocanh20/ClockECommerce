using clockECommerce.ViewModels.Catalog.Categories;
using clockECommerce.ViewModels.Catalog.Products;
using clockECommerce.ViewModels.Common;

namespace clockECommerce.WebApp.Models
{
    public class ProductCategoryViewModel : PagingRequestBase
    {
        public CategoryViewModel Category { get; set; }

        public PagedResult<ProductViewModel> Products { get; set; }
    }
}
