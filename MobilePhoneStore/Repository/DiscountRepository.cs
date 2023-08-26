using MobilePhoneStore.DBContext;
using MobilePhoneStore.Models;

namespace MobilePhoneStore.Repository
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly MobileStoreDBContext _dbContext;

        public DiscountRepository(MobileStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Discount discount)
        {
            await _dbContext.Discount.AddAsync(discount);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Discount> GetById(int id)
        {
            return await _dbContext.Discount.FindAsync(id);
        }

        public async Task Update(Discount discount)
        {
            _dbContext.Discount.Update(discount);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var discount = await _dbContext.Discount.FindAsync(id);
            if (discount != null)
            {
                _dbContext.Discount.Remove(discount);
                await _dbContext.SaveChangesAsync();
            }
        }


    }
}
