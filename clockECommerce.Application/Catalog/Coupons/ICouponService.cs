using clockECommerce.ViewModels.Catalog.Products;
using clockECommerce.ViewModels.Common;
using clockECommerce.ViewModels.Sales;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace clockECommerce.Application.Catalog.Coupons
{
    public interface ICouponService
    {
        Task<int> Create(CouponCreateRequest request);

        Task<int> Update(CouponUpdateRequest request);

        Task<int> Delete(int couponId);

        Task<PagedResult<CouponViewModel>> GetAllPaging(GetManageProductPagingRequest request);

        Task<List<CouponViewModel>> GetAll();

        Task<CouponViewModel> GetById(int id);
    }
}