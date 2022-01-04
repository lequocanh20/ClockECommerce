using clockECommerce.ViewModels.Catalog.Reports;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace clockECommerce.ApiIntegration
{
    public interface IReportApiClient
    {
        Task<List<ReportCreateRequest>> GetMonth();
        Task<List<ReportCreateRequest>> GetYear();
        Task<List<ReportViewModel>> GetReport(ReportCreateRequest request);
    }
}
