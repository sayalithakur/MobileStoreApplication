using MobilePhoneStore.Models;

namespace MobilePhoneStore.Repository
{
    public interface IDiscountRepository
    {
        Task Create(Discount discount);
        Task<Discount> GetById(int id);
        Task Update(Discount discount);
        Task Delete(int id);
    }
}
