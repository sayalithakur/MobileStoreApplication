using Microsoft.AspNetCore.Mvc;
using MobilePhoneStore.Models;
using MobilePhoneStore.Repository;

namespace MobilePhoneStore.Controllers
{
    [ApiController]
    [Route("/mobilephones")]
    public class MobilePhoneController : ControllerBase
    {
        private readonly IMobilePhoneRepository _mobilePhoneRepository;

        public MobilePhoneController(IMobilePhoneRepository mobilePhoneRepository)
        {
            _mobilePhoneRepository = mobilePhoneRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(MobilePhone mobilePhone)
        {
            await _mobilePhoneRepository.Create(mobilePhone);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var mobilePhone = await _mobilePhoneRepository.GetById(id);
            if (mobilePhone == null)
            {
                return NotFound();
            }
            return Ok(mobilePhone);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MobilePhone mobilePhone)
        {
            if (id != mobilePhone.MobilePhoneID)
            {
                return BadRequest();
            }
            await _mobilePhoneRepository.Update(mobilePhone);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mobilePhoneRepository.Delete(id);
            return Ok();
        }
    }
}
