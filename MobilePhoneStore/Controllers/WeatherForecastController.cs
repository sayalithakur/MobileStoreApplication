using Microsoft.AspNetCore.Mvc;
using MobilePhoneStore.Models;
using MobilePhoneStore.Repository;

namespace MobilePhoneStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IBrandRepository brandRepository;
     public WeatherForecastController(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(Brand brand)
        {
            await brandRepository.Create(brand);
            return Ok();
        }
        [HttpGet]
        
        public async Task<IActionResult> GetAll()
        {
            var data = await brandRepository.GetAll();
            return Ok(data);
        }
    }
}