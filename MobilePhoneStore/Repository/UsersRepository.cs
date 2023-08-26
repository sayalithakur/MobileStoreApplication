using MobilePhoneStore.DBContext;
using MobilePhoneStore.Models;

namespace MobilePhoneStore.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly MobileStoreDBContext _dbContext;

        public UsersRepository(MobileStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Users user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Users> GetById(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task Update(Users user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
