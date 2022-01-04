using clockECommerce.ViewModels.Catalog.Products;
using clockECommerce.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace clockECommerce.ApiIntegration
{
    public interface IProductApiClient
    {
        Task<PagedResult<ProductViewModel>> GetPagings(GetManageProductPagingRequest request);

        Task<PagedResult<ProductViewModel>> GetAllByCategoryPaging(GetPublicProductPagingRequest request);

        Task<bool> CreateProduct(ProductCreateRequest request);

        Task<bool> UpdateProduct(ProductUpdateRequest request);

        Task<bool> DeleteProduct(int id);

        Task<ProductViewModel> GetById(int id);

        Task<List<ProductViewModel>> GetFeaturedProducts(string languageId, int take);

        Task<List<ProductViewModel>> GetLatestProducts(string languageId, int take);

        Task<string> AddReview(ProductDetailViewModel model);

        Task<List<ProductViewModel>> GetAll();
    }
}