using clockECommerce.Data.EF;
using clockECommerce.Ultilities.Exceptions;
using clockECommerce.ViewModels.Catalog.Products;
using clockECommerce.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using clockECommerce.Data.Entities;
using clockECommerce.ViewModels.Ultilities.Enums;

namespace clockECommerce.Application.Catalog.Reviews
{
    public class ReviewService : IReviewService
    {
        private readonly clockECommerceDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ReviewService(clockECommerceDbContext context,
            UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<ApiResult<bool>> BrowserReview(int reviewId)
        {
            var review = await _context.Reviews.FindAsync(reviewId);
            var status = (int)review.Status;

            switch (status)
            {
                case 0:
                    review.Status = (Data.Enums.Status)1;
                    break;

                case 1:
                    review.Status = (Data.Enums.Status)0;
                    break;
            }

            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<int> Delete(int reviewId)
        {
            var review = await _context.Reviews.FindAsync(reviewId);
            if (review == null) throw new clockECommerceException($"Không thể tìm bình luận có ID: {review} ");

            _context.Reviews.Remove(review);

            return await _context.SaveChangesAsync();
        }

        public async Task<List<ReviewViewModel>> GetAll()
        {
            var query = from r in _context.Reviews
                        select new { r };

            return await query.Select(x => new ReviewViewModel()
            {
                Id = x.r.Id,
                UserId = x.r.UserId,
                UserName = x.r.AppUser.Name,
                ProductId = x.r.ProductId,
                Comments = x.r.Comments,
                Rating = x.r.Rating,
                PublishedDate = x.r.PublishedDate,
                Status = (Status)x.r.Status
            }).ToListAsync();
        }

        public async Task<PagedResult<ReviewViewModel>> GetAllPaging(GetManageProductPagingRequest request)
        {
            var query = from r in _context.Reviews
                        select new { r };

            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.r.Comments.Contains(request.Keyword));

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query
                .OrderBy(x => x.r.PublishedDate)
                .OrderBy(x => x.r.Status)              
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)                
                .Select(x => new ReviewViewModel()
                {
                    Id = x.r.Id,
                    UserId = x.r.UserId,
                    UserName = x.r.AppUser.Name,
                    ProductId = x.r.ProductId,
                    Comments = x.r.Comments,
                    Rating = x.r.Rating,
                    PublishedDate = x.r.PublishedDate,
                    Status = (Status)x.r.Status
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<ReviewViewModel>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<ReviewViewModel> GetById(int id)
        {
            var query = from r in _context.Reviews
                        where r.Id == id
                        select new { r };

            return await query.Select(x => new ReviewViewModel()
            {
                Id = x.r.Id,
                UserId = x.r.UserId,
                UserName = x.r.AppUser.Name,
                ProductId = x.r.ProductId,
                Comments = x.r.Comments,
                Rating = x.r.Rating,
                PublishedDate = x.r.PublishedDate,
                Status = (Status)x.r.Status
            }).FirstOrDefaultAsync();
        }

        public async Task<int> Update(ReviewUpdateRequest request)
        {
            var review = await _context.Reviews.FindAsync(request.Id);
            if (review == null) throw new clockECommerceException($"Không thể tìm bình luận có ID: {request.Id} ");

            review.Comments = request.Comments;
            review.Status = (Data.Enums.Status)request.Status;

            return await _context.SaveChangesAsync();
        }
    }
}
