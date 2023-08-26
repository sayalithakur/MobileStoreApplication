using Microsoft.EntityFrameworkCore;
using MobilePhoneStore.DBContext;
using MobilePhoneStore.Models;

namespace MobilePhoneStore.Repository
{
    public class SaleRepository : ISaleRepository
    {
        private readonly MobileStoreDBContext _dbContext;

        public SaleRepository(MobileStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Sale sale)
        {
            await _dbContext.Sale.AddAsync(sale);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Sale>> GetSalesByDateRange(DateTime fromDate, DateTime toDate)
        {
            return await _dbContext.Sale
                .Where(s => s.SaleDate >= fromDate && s.SaleDate <= toDate)
                .ToListAsync();
        }

        public async Task<Dictionary<string, decimal>> GetBrandWiseSalesByDateRange(DateTime fromDate, DateTime toDate)
        {
            var brandSales = await _dbContext.Sale
                .Include(s => s.MobilePhone.Brand)
                .Where(s => s.SaleDate >= fromDate && s.SaleDate <= toDate)
                .GroupBy(s => s.MobilePhone.Brand.BrandName)
                .Select(g => new { BrandName = g.Key, TotalSales = g.Sum(s => s.TotalPrice) })
                .ToDictionaryAsync(g => g.BrandName, g => g.TotalSales);

            return brandSales;
        }

        public async Task<decimal> CalculateProfitLossForDateRange(DateTime fromDate, DateTime toDate)
        {
            var sales = await _dbContext.Sale
                .Include(s => s.Discounts)
                .Where(s => s.SaleDate >= fromDate && s.SaleDate <= toDate)
                .ToListAsync();

            decimal totalProfitLoss = sales.Sum(s => s.TotalPrice - s.Discounts.Sum(d => d.DiscountAmount));
            return totalProfitLoss;
        }

    }
}
