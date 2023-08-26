using MobilePhoneStore.DBContext;
using MobilePhoneStore.Models;

namespace MobilePhoneStore.Repository
{
    public class MobilePhoneRepository : IMobilePhoneRepository
    {
        private readonly MobileStoreDBContext _dbContext;

        public MobilePhoneRepository(MobileStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }

         public async Task Create(MobilePhone mobilePhone)
          {
              await _dbContext.MobilePhone.AddAsync(mobilePhone);
             await _dbContext.SaveChangesAsync();

            
          }
       

        public async Task<MobilePhone> GetById(int id)
        {
            return await _dbContext.MobilePhone.FindAsync(id);
        }

        public async Task Update(MobilePhone mobilePhone)
        {
            _dbContext.MobilePhone.Update(mobilePhone);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var mobilePhone = await _dbContext.MobilePhone.FindAsync(id);
            if (mobilePhone != null)
            {
                _dbContext.MobilePhone.Remove(mobilePhone);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
