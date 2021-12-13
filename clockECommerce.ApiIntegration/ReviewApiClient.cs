using clockECommerce.Ultilities.Constants;
using clockECommerce.ViewModels.Catalog.Products;
using clockECommerce.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace clockECommerce.ApiIntegration
{
    public class ReviewApiClient : BaseApiClient, IReviewApiClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ReviewApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> BrowserReview(int id)
        {
            var sessions = _httpContextAccessor
                             .HttpContext
                             .Session
                             .GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var json = JsonConvert.SerializeObject(id);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PatchAsync($"/api/reviews/browserReview/{id}", httpContent);
            if (response.IsSuccessStatusCode)
                return true;
            return false;
        }

        public async Task<bool> DeleteReview(int id)
        {
            return await Delete($"/api/reviews/" + id);

        }

        public async Task<List<ReviewViewModel>> GetAll()
        {
            return await GetListAsync<ReviewViewModel>("/api/reviews");
        }

        public async Task<PagedResult<ReviewViewModel>> GetAllPaging(GetManageProductPagingRequest request)
        {
            var data = await GetAsync<PagedResult<ReviewViewModel>>(
               $"/api/reviews/paging?pageIndex={request.PageIndex}" +
               $"&pageSize={request.PageSize}" +
               $"&keyword={request.Keyword}&sortOption={request.SortOption}");

            return data;
        }

        public async Task<ReviewViewModel> GetById(int id)
        {
            return await GetAsync<ReviewViewModel>($"/api/reviews/{id}");
        }

        public async Task<bool> UpdateReview(ReviewUpdateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"/api/reviews/updateReview", httpContent);
            return response.IsSuccessStatusCode;
        }
    }
}
