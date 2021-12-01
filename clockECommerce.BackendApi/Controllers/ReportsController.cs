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
        public ReportsController(IGeneratePdf generatePdf)
        {
            _generatePdf = generatePdf;
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
        [Route("GetEmp")]
        public IActionResult GetOrderInfo()
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
            //return await _generatePdf.GetPdf("Views/Order/OrderInfo.cshtml", empObj);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("OrderInfo");
                var currentRow = 2;
                var header = worksheet.Range("A1:K1");
                header.Merge();
                header.Value = "Order Information";
                header.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thick);
                header.Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
                header.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                header.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                header.Style.Font.FontSize = 12;
                header.Style.Fill.BackgroundColor = XLColor.BallBlue;

                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "Name";
                worksheet.Cell(currentRow, 3).Value = "Address";
                worksheet.Cell(currentRow, 4).Value = "OrderDate";
                worksheet.Cell(currentRow, 5).Value = "Email";
                worksheet.Cell(currentRow, 6).Value = "PhoneNumber";
                worksheet.Cell(currentRow, 7).Value = "Price";
                worksheet.Cell(currentRow, 8).Value = "ShipName";
                worksheet.Cell(currentRow, 9).Value = "ShipAddress";
                worksheet.Cell(currentRow, 10).Value = "ShipPhoneNumber";
                foreach (var order in obj)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = order.Id;
                    worksheet.Cell(currentRow, 2).Value = order.Name;
                    worksheet.Cell(currentRow, 3).Value = order.Address;
                    worksheet.Cell(currentRow, 4).Value = order.OrderDate;
                    worksheet.Cell(currentRow, 5).Value = order.Email;
                    worksheet.Cell(currentRow, 6).Value = order.PhoneNumber;
                    worksheet.Cell(currentRow, 7).Value = order.Price;
                    worksheet.Cell(currentRow, 8).Value = order.ShipName;
                    worksheet.Cell(currentRow, 9).Value = order.ShipAddress;
                    worksheet.Cell(currentRow, 10).Value = order.ShipPhoneNumber;
                }

                worksheet.Columns(1, 8).AdjustToContents();
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
