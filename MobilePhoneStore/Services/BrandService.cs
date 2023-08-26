using MobilePhoneStore.Models;
using MobilePhoneStore.Repository;

namespace MobilePhoneStore.Services
{
    public class BrandService: IBrandService
    {
        private readonly IBrandRepository brandRepository;
        public BrandService(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public Task Create(Brand brand)
        {
            return brandRepository.Create(brand);
        }

    }
}
