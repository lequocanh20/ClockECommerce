using clockECommerce.ApiIntegration;
using clockECommerce.ViewModels.Catalog.Reports;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace clockECommerce.AdminApp.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportApiClient _reportApiClient;
        public ReportController(IReportApiClient reportApiClient)
        {
            _reportApiClient = reportApiClient;
        }
        public async Task<IActionResult> Index(int? month, int? year)
        {
            var months = await _reportApiClient.GetMonth();
            month = months.Select(x => x.Month).FirstOrDefault();
            ViewBag.Months = months.Select(x => new SelectListItem()
            {
                Text = x.Month.ToString(),
                Value = x.Month.ToString(),
                Selected = month.HasValue && month.Value == x.Month
            });

            var years = await _reportApiClient.GetYear();
            year = years.Select(x => x.Year).FirstOrDefault();
            ViewBag.Years = years.Select(x => new SelectListItem()
            {
                Text = x.Year.ToString(),
                Value = x.Year.ToString(),
                Selected = year.HasValue && year.Value == x.Year
            });
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Report(ReportCreateRequest request)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("ReportInfo");
                var currentRow = 2;
                var header = worksheet.Range("A1:C1");
                header.Merge();
                header.Value = "Thống kê doanh thu tháng " + request.Month;
                header.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thick);
                header.Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
                header.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                header.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                header.Style.Font.FontSize = 12;
                header.Style.Fill.BackgroundColor = XLColor.BallBlue;

                worksheet.Cell(currentRow, 1).Value = "ProductID";
                worksheet.Cell(currentRow, 2).Value = "TotalRevenueOfProduct";
                foreach (var order in await _reportApiClient.GetReport(request))
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = order.ProductID;
                    worksheet.Cell(currentRow, 2).Value = order.TotalRevenueOfProduct;
                }
                var order1 = await _reportApiClient.GetReport(request);
                worksheet.Cell(2, 3).Value = "Total";
                worksheet.Cell(3, 3).Value = order1.Select(c => c.Total).Distinct();

                worksheet.Columns(1, 3).AdjustToContents();
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Orders.xlsx"
                        );
                }
            }
        }
    }
}
