using clockECommerce.Application.Catalog.Reports;
using clockECommerce.Data.EF;
using clockECommerce.ViewModels.Catalog.Reports;
using clockECommerce.ViewModels.Sales;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace clockECommerce.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IGeneratePdf _generatePdf;
        private readonly clockECommerceDbContext _context;
        private readonly IReportService _reportService;
        public ReportsController(IGeneratePdf generatePdf,
            clockECommerceDbContext context,
            IReportService reportService)
        {
            _generatePdf = generatePdf;
            _context = context;
            _reportService = reportService;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetEmployeeInfo()
        {
            var empObj = new OrderViewModel
            {
                Id = 1,
                Name = "Quoc Anh",
                PhoneNumber = "0774642207",
                Address = "Binh Chanh",
                Email = "lequocanh.qa@gmail.com",
                OrderDate = new DateTime(2021, 11, 27),
                Price = 6600000,
                ShipName = "Quoc Anh",
                ShipAddress = "Binh Chanh",
                ShipPhoneNumber = "0774642207"
            };
            List<OrderViewModel> obj = new List<OrderViewModel>();
            obj.Add(empObj);
            return await _generatePdf.GetPdf("Views/Order/OrderInfo.cshtml", empObj);
        }

        [HttpGet]
        [Route("GetMonth")]
        public async Task<IActionResult> GetMonth()
        {
            var months = await _reportService.GetMonth();
            return Ok(months);
        }

        [HttpGet]
        [Route("GetYear")]
        public async Task<IActionResult> GetYear()
        {
            var years = await _reportService.GetYear();
            return Ok(years);
        }

        [HttpGet]
        [Route("GetReport")]
        public async Task<IActionResult> GetReport([FromQuery] ReportCreateRequest request)
        {
            var data = await _reportService.GetReport(request);
            return Ok(data);
        }
    }
}
