using MobilePhoneStore.Models;

namespace MobilePhoneStore.Repository
{
    public interface IMobilePhoneRepository
    {
        Task Create(MobilePhone mobilePhone);
        Task<MobilePhone> GetById(int id);
        Task Update(MobilePhone mobilePhone);
        Task Delete(int id);
           

    }
}
