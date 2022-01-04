using clockECommerce.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace clockECommerce.WebApp.Controllers.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PagedResultBase result)
        {
            // Tất cả những thằng nào mà muốn phân trang thì chỉ cần truyền vào đây thôi
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}
