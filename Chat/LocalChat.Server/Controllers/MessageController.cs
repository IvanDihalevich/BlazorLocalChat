using AutoMapper;
using LocalChat.Core.Entities;
using LocalChat.Reposetory.CommonR;
using Microsoft.AspNetCore.Mvc;
using Server.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalChat.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IRepository<Message, Guid> _messageRepository;
        private readonly IMapper _mapper;

        public MessageController(IRepository<Message, Guid> messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllMessagesAsync()
        {
            var messages = _mapper.Map<List<MessageModel>>(await _messageRepository.GetAllAsync());
            return Ok(messages);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddMessageAsync(MessageCreate messageCreate)
        {
            var message = _mapper.Map<Message>(messageCreate);
            await _messageRepository.CreateAsync(message);
            await _messageRepository.SaveAsync();
            return Ok($"Message {message.Id} added");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var message = await _messageRepository.GetAsync(id);
            if (message == null)
                return NotFound("Message not found");

            await _messageRepository.DeleteAsync(id);
            await _messageRepository.SaveAsync();
            return Ok($"Message {message.Id} deleted");
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, MessageUpdate messageUpdate)
        {
            var existingMessage = await _messageRepository.GetAsync(id);
            if (existingMessage == null)
                return NotFound("Message not found");

            _mapper.Map(messageUpdate, existingMessage);
            await _messageRepository.UpdateAsync(existingMessage);
            await _messageRepository.SaveAsync();
            return Ok($"Message {existingMessage.Id} updated");
        }
    }
}
