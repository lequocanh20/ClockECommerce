using clockECommerce.ViewModels.Common;
using clockECommerce.ViewModels.Sales;
using System.Threading.Tasks;

namespace clockECommerce.ApiIntegration
{
    public interface IOrderApiClient
    {
        Task<string> CreateOrder(CheckoutRequest request);

        Task<PagedResult<OrderViewModel>> GetPagings(GetManageOrderPagingRequest request);

        Task<bool> UpdateOrderStatus(int id);

        Task<bool> CancelOrderStatus(int id);

        Task<OrderByUserViewModel> GetOrderByUser(string id);

        Task<OrderViewModel> GetOrderById(int orderId);
    }
}