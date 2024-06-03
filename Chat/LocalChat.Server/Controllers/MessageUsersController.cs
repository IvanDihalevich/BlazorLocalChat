using AutoMapper;
using LocalChat.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocalChat.Reposetory.CommonR;
using Server.Infrastructure;

namespace LocalChat.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageUsersController : ControllerBase
    {
        private readonly IRepository<MessegeUsers, Guid> _messageUsersRepository;
        private readonly IMapper _mapper;

        public MessageUsersController(IRepository<MessegeUsers, Guid> messageUsersRepository, IMapper mapper)
        {
            _messageUsersRepository = messageUsersRepository;
            _mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllMessageUsersAsync()
        {
            var messageUsers = await _messageUsersRepository.GetAllAsync();
            var mappedResult = _mapper.Map<List<MessegeUsersModel>>(messageUsers);
            return Ok(mappedResult);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddMessageUserAsync(MessegeUsersCreate objCreate)
        {
            var obj = _mapper.Map<MessegeUsers>(objCreate);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _messageUsersRepository.CreateAsync(obj);
            await _messageUsersRepository.SaveAsync();

            return Ok($"obj {obj.Id} added");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var obj = await _messageUsersRepository.GetAsync(id);
            if (obj is null)
                return BadRequest("obj not found");

            await _messageUsersRepository.DeleteAsync(id);
            await _messageUsersRepository.SaveAsync();

            return Ok($"obj {obj.Id} deleted");
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, MessegeUsersUpdate objUpdate)
        {
            var existingobj = await _messageUsersRepository.GetAsync(id);
            if (existingobj is null)
                return NotFound("obj not found");

            _mapper.Map(objUpdate, existingobj);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _messageUsersRepository.UpdateAsync(existingobj);
            await _messageUsersRepository.SaveAsync();

            return Ok($"obj {existingobj.Id} updated");
        }
    }
}
