using clockECommerce.ApiIntegration;
using clockECommerce.ViewModels.Catalog.Products;
using clockECommerce.ViewModels.Sales;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace clockECommerce.AdminApp.Controllers
{
    public class ReviewController : BaseController
    {
        private readonly IReviewApiClient _reviewApiClient;

        public ReviewController(IReviewApiClient reviewApiClient)
        {
            _reviewApiClient = reviewApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetManageProductPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
            };

            var data = await _reviewApiClient.GetAllPaging(request);
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int reviewId)
        {
            var review = await _reviewApiClient.GetById(reviewId);

            var editVm = new ReviewUpdateRequest()
            {
                Id = review.Id,
                UserId = review.UserId,
                UserName = review.UserName,
                ProductId = review.ProductId,
                Comments = review.Comments,
                Rating = review.Rating,
                PublishedDate = review.PublishedDate,
                Status = review.Status
            };

            return View(editVm);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit([FromForm] ReviewUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var result = await _reviewApiClient.UpdateReview(request);
            if (result)
            {
                TempData["UpdateReviewSuccessful"] = "Cập nhật bình luận thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Cập nhật bình luận thất bại");
            return View(request);
        }

        [HttpGet]
        public IActionResult Delete(int reviewId)
        {
            return View(new ReviewDeleteRequest()
            {
                Id = reviewId
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CouponDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _reviewApiClient.DeleteReview(request.Id);
            if (result)
            {
                TempData["DeleteReviewSuccessful"] = "Xóa bình luận thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Xóa bình luận không thành công");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var review = await _reviewApiClient.GetById(id);

            var detailVm = new ReviewViewModel()
            {
                Id = review.Id,
                UserId = review.UserId,
                UserName = review.UserName,
                ProductId = review.ProductId,
                Comments = review.Comments,
                Rating = review.Rating,
                PublishedDate = review.PublishedDate
            };

            return View(detailVm);
        }

        [HttpPost]
        public async Task<IActionResult> BrowserReview(int reviewId)
        {
            var result = await _reviewApiClient.BrowserReview(reviewId);
            if (result)
            {
                TempData["result"] = "Cập nhật trạng thái bình luận thành công";
                return RedirectToAction("Index");
            }

            TempData["resultFail"] = "Cập nhật trạng thái bình luận không thành công";
            return RedirectToAction("Index", "Review");
        }
    }
}