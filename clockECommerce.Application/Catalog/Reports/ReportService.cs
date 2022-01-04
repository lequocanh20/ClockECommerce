using clockECommerce.Data.EF;
using clockECommerce.ViewModels.Catalog.Reports;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using clockECommerce.ViewModels.Sales;
using Microsoft.EntityFrameworkCore;

namespace clockECommerce.Application.Catalog.Reports
{
    public class ReportService : IReportService
    {
        private readonly clockECommerceDbContext _context;
        public ReportService(clockECommerceDbContext context)
        {
            _context = context;
        }
        public async Task<List<ReportCreateRequest>> GetMonth()
        {
            var query = from o in _context.Orders
                        select o.OrderDate;


            return await query.Select(x => new ReportCreateRequest
            {
                Month = x.Month
            }).Distinct().ToListAsync();
        }

        public async Task<List<ReportViewModel>> GetReport(ReportCreateRequest request)
        {
            var query = from od in _context.OrderDetails
                        join o in _context.Orders on od.OrderId equals o.Id
                        where o.OrderDate.Month == request.Month && o.OrderDate.Year == request.Year
                        select new { o, od };
            var products = from p in _context.Products
                           select new { p };
            var data = await query
                .Select(x => new ReportViewModel()
                {
                    ProductID = x.od.Product.Name,
                    TotalRevenueOfProduct = query.Where(c => c.od.ProductId == products.Select(c => c.p.Id).SingleOrDefault()).Select(c => c.o.Total).Sum(),
                    Total = query.Select(c => c.o.Total).Sum()
                }).Distinct().ToListAsync();
            return data;
        }

        public async Task<List<ReportCreateRequest>> GetYear()
        {
            var query = from o in _context.Orders
                        select o.OrderDate;


            return await query.Select(x => new ReportCreateRequest
            {
                Year = x.Year
            }).Distinct().ToListAsync();
        }
    }
}
