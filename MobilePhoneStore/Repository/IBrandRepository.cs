using MobilePhoneStore.Models;

namespace MobilePhoneStore.Repository
{
    public interface IBrandRepository 
    {
        Task Create(Brand brand);
        Task Delete(int id);
        Task<List<Brand>> GetAll();
        Task<Brand> GetById(int id);
        Task BulkInsertBrands(List<Brand> brands);
        Task BulkUpdateBrands(List<Brand> brands);


    }
}
