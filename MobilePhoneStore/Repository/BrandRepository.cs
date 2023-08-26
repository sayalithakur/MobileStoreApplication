using Microsoft.EntityFrameworkCore;
using MobilePhoneStore.DBContext;
using MobilePhoneStore.Models;

namespace MobilePhoneStore.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly MobileStoreDBContext mobileStoreDBContext;
        public BrandRepository(MobileStoreDBContext mobileStoreDBContext)
        {
            this.mobileStoreDBContext = mobileStoreDBContext;
        }
        public Task Create(Brand brand)
        {
            var data = mobileStoreDBContext.Brand.Add(brand);
            mobileStoreDBContext.SaveChanges();
            return Task.FromResult(data);
        }

        public async Task Delete(int id)
        {
            var data = await mobileStoreDBContext.Brand.FindAsync(id);
            if (data != null)
            {
                mobileStoreDBContext.Brand.Remove(data);
                mobileStoreDBContext.SaveChanges();
            }

        }

        public async Task<List<Brand>> GetAll()
        {
            var data = await mobileStoreDBContext.Brand.ToListAsync();
            return data;
        }

        public async Task<Brand> GetById(int id)
        {
            var data = await mobileStoreDBContext.Brand.FindAsync(id);
            return data;
        }


        public async Task BulkInsertBrands(List<Brand> brands)
        {
          await mobileStoreDBContext.Brand.AddRangeAsync(brands);
            mobileStoreDBContext.SaveChanges();
            
        }

        public async Task BulkUpdateBrands(List<Brand> brands)
        {
            foreach (var brand in brands)
            {
                var brandData = await mobileStoreDBContext.Brand.FindAsync(brand.BrandID);
                brandData.BrandName = brand.BrandName;
                brandData.Country = brand.Country;
                mobileStoreDBContext.Brand.Update(brandData);
                mobileStoreDBContext.SaveChanges();
            }
           

        }

    }
}
