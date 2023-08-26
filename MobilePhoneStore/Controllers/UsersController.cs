using Microsoft.AspNetCore.Mvc;
using MobilePhoneStore.Models;
using MobilePhoneStore.Repository;

namespace MobilePhoneStore.Controllers
{
    [ApiController]
    [Route("/users")]
    public class UsersController :ControllerBase
    {
        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Users user)
        {
            await _usersRepository.Create(user);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _usersRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Users user)
        {
            if (id != user.UserID)
            {
                return BadRequest();
            }
            await _usersRepository.Update(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _usersRepository.Delete(id);
            return Ok();
        }
    }
}
