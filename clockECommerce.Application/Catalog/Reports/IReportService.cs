using clockECommerce.ViewModels.Catalog.Reports;
using clockECommerce.ViewModels.Sales;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace clockECommerce.Application.Catalog.Reports
{
    public interface IReportService
    {
        Task<List<ReportCreateRequest>> GetMonth();
        Task<List<ReportCreateRequest>> GetYear();
        Task<List<ReportViewModel>> GetReport(ReportCreateRequest request);
    }
}
