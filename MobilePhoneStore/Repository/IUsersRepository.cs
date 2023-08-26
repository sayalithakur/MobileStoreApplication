using MobilePhoneStore.Models;

namespace MobilePhoneStore.Repository
{
    public interface IUsersRepository
    {
        Task Create(Users user);
        Task<Users> GetById(int id);
        Task Update(Users user);
        Task Delete(int id);
    }
}
