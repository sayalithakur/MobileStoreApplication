using MobilePhoneStore.Models;

namespace MobilePhoneStore.Repository
{
    public interface ISaleRepository
    {
        Task Create(Sale sale);
        Task<List<Sale>> GetSalesByDateRange(DateTime fromDate, DateTime toDate);
        Task<Dictionary<string, decimal>> GetBrandWiseSalesByDateRange(DateTime fromDate, DateTime toDate);
        Task<decimal> CalculateProfitLossForDateRange(DateTime fromDate, DateTime toDate);
    }
}
