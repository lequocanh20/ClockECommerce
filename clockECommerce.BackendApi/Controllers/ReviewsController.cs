using clockECommerce.Application.Catalog.Reviews;
using clockECommerce.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clockECommerce.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reviews = await _reviewService.GetAll();
            return Ok(reviews);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetManageProductPagingRequest request)
        {
            var reviews = await _reviewService.GetAllPaging(request);
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var review = await _reviewService.GetById(id);
            return Ok(review);
        }

        // HttpPut: update toàn phần
        [HttpPut("updateReview")]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] ReviewUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedResult = await _reviewService.Update(request);
            if (affectedResult == 0)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var affectedResult = await _reviewService.Delete(id);
            if (affectedResult == 0)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPatch("browserReview/{id}")]
        public async Task<IActionResult> BrowserReview([FromBody] int id)
        {
            var result = await _reviewService.BrowserReview(id);
            if (result.IsSuccessed)
                return Ok();
            return BadRequest("Không duyệt được bình luận");
        }
    }
}
