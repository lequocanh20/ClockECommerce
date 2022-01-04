using clockECommerce.ViewModels.Catalog.Products;
using clockECommerce.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace clockECommerce.ApiIntegration
{
    public interface IReviewApiClient
    {
        Task<List<ReviewViewModel>> GetAll();

        Task<ReviewViewModel> GetById(int id);

        Task<bool> UpdateReview(ReviewUpdateRequest request);

        Task<bool> DeleteReview(int id);

        Task<PagedResult<ReviewViewModel>> GetAllPaging(GetManageProductPagingRequest request);

        Task<bool> BrowserReview(int id);
    }
}
