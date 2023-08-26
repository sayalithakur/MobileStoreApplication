using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobilePhoneStore.DBContext;
using MobilePhoneStore.Models;
using MobilePhoneStore.Repository;
using System.Linq;

namespace MobilePhoneStore.Controllers
{
    [ApiController]
    [Route("/sales")]
    public class SaleController :ControllerBase
    {
        private readonly ISaleRepository _saleRepository;
        private readonly MobileStoreDBContext mobileStoreDBContext;


        public SaleController(ISaleRepository saleRepository, MobileStoreDBContext mobileStoreDBContext)
        {
            this.mobileStoreDBContext= mobileStoreDBContext;    
            _saleRepository = saleRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Sale sale)
        {
            await _saleRepository.Create(sale);
            return Ok();
        }

        [HttpGet("monthly-sales")]
        public JsonResult GetMonthlySalesReport()
        {
            var monthlySalesReport = mobileStoreDBContext.Sale
                .GroupBy(sale => new
                {
                    Year = sale.SaleDate.Year,
                    Month = sale.SaleDate.Month
                })
                .Select(group => new
                {
                    Year = group.Key.Year,
                    Month = group.Key.Month,
                    TotalSalesAmount = group.Sum(sale => sale.TotalPrice)
                })
                .OrderBy(report => report.Year)
                .ThenBy(report => report.Month)
                .ToList();

            return new JsonResult(monthlySalesReport);
        }


        [HttpGet("brand-wise-sales")]
        public async Task<IActionResult> GetBrandWiseSales(DateTime fromDate, DateTime toDate)
        {
            var brandSales = await _saleRepository.GetBrandWiseSalesByDateRange(fromDate, toDate);
            return Ok(brandSales);
        }

        [HttpGet("ProfitLossComparison")]
        public IActionResult GetProfitLossComparison(DateTime currentFromDate, DateTime currentToDate, DateTime previousFromDate, DateTime previousToDate)
        {
            var currentPeriodSales = mobileStoreDBContext.Sale
                .Where(sale => sale.SaleDate >= currentFromDate && sale.SaleDate <= currentToDate)
                .Sum(sale => sale.TotalPrice);

            var previousPeriodSales = mobileStoreDBContext.Sale
                .Where(sale => sale.SaleDate >= previousFromDate && sale.SaleDate <= previousToDate)
                .Sum(sale => sale.TotalPrice);

            var profitLossReport = new
            {
                CurrentPeriodSales = currentPeriodSales,
                PreviousPeriodSales = previousPeriodSales,
                ProfitLoss = currentPeriodSales - previousPeriodSales
            };

            return Ok(profitLossReport); // Returns a JSON response
        }



        [HttpGet("profit-loss")]
        public async Task<IActionResult> GetProfitLoss(DateTime fromDate, DateTime toDate)
        {
            var profitLoss = await _saleRepository.CalculateProfitLossForDateRange(fromDate, toDate);
            return Ok(profitLoss);
        }
        [HttpGet("MonthlyBrandWiseSales")]
        public IActionResult GetMonthlyBrandWiseSales(DateTime fromDate, DateTime toDate)
        {
            var monthlySalesReport = mobileStoreDBContext.Sale
                .Where(sale => sale.SaleDate >= fromDate && sale.SaleDate <= toDate)
                .GroupBy(sale => new
                {
                    Year = sale.SaleDate.Year,
                    Month = sale.SaleDate.Month,
                    BrandName = sale.MobilePhone.Brand.BrandName
                })
                .Select(group => new
                {
                    Year = group.Key.Year,
                    Month = group.Key.Month,
                    BrandName = group.Key.BrandName,
                    TotalSalesAmount = group.Sum(sale => sale.TotalPrice)
                })
                .OrderBy(report => report.Year)
                .ThenBy(report => report.Month)
                .ThenBy(report => report.BrandName)
                .ToList();

            return Ok(monthlySalesReport); // Returns a JSON response
        }
    }

}
