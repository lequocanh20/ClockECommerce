using clockECommerce.ViewModels.Catalog.Products;
using clockECommerce.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace clockECommerce.Application.Catalog.Reviews
{
    public interface IReviewService
    {
        Task<int> Update(ReviewUpdateRequest request);

        Task<int> Delete(int reviewId);

        Task<PagedResult<ReviewViewModel>> GetAllPaging(GetManageProductPagingRequest request);

        Task<List<ReviewViewModel>> GetAll();

        Task<ReviewViewModel> GetById(int id);

        Task<ApiResult<bool>> BrowserReview(int reviewId);
    }
}
