using clockECommerce.ViewModels.Catalog.Reports;
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
    public class ReportApiClient : BaseApiClient, IReportApiClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ReportApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<ReportCreateRequest>> GetMonth()
        {
            return await GetListAsync<ReportCreateRequest>("/api/reports/GetMonth");
        }

        public async Task<List<ReportCreateRequest>> GetYear()
        {
            return await GetListAsync<ReportCreateRequest>("/api/reports/GetYear");
        }
        public async Task<List<ReportViewModel>> GetReport(ReportCreateRequest request)
        {
            return await GetListAsync<ReportViewModel>($"/api/reports/GetReport?Month={request.Month}&Year={request.Year}");
        }
    }
}
