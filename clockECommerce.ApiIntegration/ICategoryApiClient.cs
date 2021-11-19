using clockECommerce.ViewModels.Catalog.Categories;
using clockECommerce.ViewModels.Catalog.Products;
using clockECommerce.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace clockECommerce.ApiIntegration
{
    public interface ICategoryApiClient
    {
        Task<PagedResult<CategoryViewModel>> GetAllPaging(GetManageProductPagingRequest request);

        Task<List<CategoryViewModel>> GetAll();

        Task<CategoryViewModel> GetById(int id);

        Task<bool> CreateCategory(CategoryCreateRequest request);

        Task<bool> UpdateCategory(CategoryUpdateRequest request);

        Task<bool> DeleteCategory(int id);
    }
}