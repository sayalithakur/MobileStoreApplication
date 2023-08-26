using Microsoft.AspNetCore.Mvc;
using MobilePhoneStore.Models;
using MobilePhoneStore.Repository;

namespace MobilePhoneStore.Controllers
{
    [ApiController]
    [Route("/discounts")]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountRepository _discountRepository;

        public DiscountController(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Discount discount)
        {
            await _discountRepository.Create(discount);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var discount = await _discountRepository.GetById(id);
            if (discount == null)
            {
                return NotFound();
            }
            return Ok(discount);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Discount discount)
        {
            if (id != discount.DiscountID)
            {
                return BadRequest();
            }
            await _discountRepository.Update(discount);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _discountRepository.Delete(id);
            return Ok();
        }
    }
}
