using AutoMapper;
using LocalChat.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Server.Infrastructure;
using LocalChat.Reposetory.CommonR;

namespace LocalChat.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User, Guid> _userRepository; 
        public UserController(IRepository<User, Guid> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllAdvertsAsync()
        {
            var users = await _userRepository.GetAllAsync();
            var mappedResult = _mapper.Map<List<UserModel>>(users);
            return Ok(mappedResult);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAdvertAsync(UserCreate userCreate)
        {
            var user = _mapper.Map<User>(userCreate);

            await _userRepository.CreateAsync(user);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok($"User {user.Id} added");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _userRepository.GetAsync(id);
            if (user is null)
                return BadRequest("User not found");

            await _userRepository.DeleteAsync(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok($"User {user.Id} deleted");
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UserUpdate userUpdate)
        {
            var existingUser = await _userRepository.GetAsync(id);
            if (existingUser is null)
                return NotFound("User not found");

            _mapper.Map(userUpdate, existingUser);

            await _userRepository.UpdateAsync(existingUser);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok($"User {existingUser.Id} updated");
        }
    }
}
