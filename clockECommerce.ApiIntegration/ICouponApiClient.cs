using clockECommerce.ViewModels.Catalog.Products;
using clockECommerce.ViewModels.Common;
using clockECommerce.ViewModels.Sales;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace clockECommerce.ApiIntegration
{
    public interface ICouponApiClient
    {
        Task<List<CouponViewModel>> GetAll();

        Task<CouponViewModel> GetById(int id);

        Task<bool> CreateCoupon(CouponCreateRequest request);

        Task<bool> UpdateCoupon(CouponUpdateRequest request);

        Task<bool> DeleteCoupon(int id);

        Task<PagedResult<CouponViewModel>> GetAllPaging(GetManageProductPagingRequest request);
    }
}