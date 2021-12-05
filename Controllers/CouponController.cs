using clockECommerce.ApiIntegration;
using clockECommerce.Ultilities.Constants;
using clockECommerce.ViewModels.Catalog.Products;
using clockECommerce.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace clockECommerce.WebApp.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponApiClient _couponApiClient;

        public CouponController(ICouponApiClient couponApiClient)
        {
            _couponApiClient = couponApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var request = new GetManageProductPagingRequest()
            {
                PageIndex = 1,
                PageSize = 8,
            };
            var coupons = await _couponApiClient.GetAllPaging(request);
            return View(coupons);
        }

        public async Task<IActionResult> Detail(int couponId)
        {
            var coupon = await _couponApiClient.GetById(couponId);
            return View(coupon);
        }

        [HttpPost]
        public async Task<int> ApplyCoupon(string code)
        {
            var coupons = await _couponApiClient.GetAll();
            var coupon = coupons.FirstOrDefault(x => x.Code == code);

            if (coupon == null)
            {
                return -2;

            }
            else if (coupon.Count <= 0)
            {
                return -1;
            }

            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            var currentCart = new CartViewModel();
            if (session != null)
            {
                currentCart = JsonConvert.DeserializeObject<CartViewModel>(session);
            }
            if (currentCart.Promotion != 0)
                return 0;

            currentCart.Promotion = coupon.Promotion;
            currentCart.CouponCode = coupon.Code;
            HttpContext.Session.SetString(SystemConstants.CartSession, JsonConvert.SerializeObject(currentCart));

            return currentCart.Promotion;
        }
    }
}