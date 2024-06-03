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
    public class ChatRoomUsersController : ControllerBase
    {
        private readonly IRepository<ChatRoomUsers, Guid> _chatRoomUsersRepository;
        private readonly IMapper _mapper;

        public ChatRoomUsersController(IRepository<ChatRoomUsers, Guid> chatRoomUsersRepository, IMapper mapper)
        {
            _chatRoomUsersRepository = chatRoomUsersRepository;
            _mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllChatRoomUsersAsync()
        {
            var chatRoomUsers = await _chatRoomUsersRepository.GetAllAsync();
            var mappedResult = _mapper.Map<List<ChatRoomUsersModel>>(chatRoomUsers);
            return Ok(mappedResult);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddChatRoomUserAsync(ChatRoomUsersCreate chatRoomUserCreate)
        {
            var chatRoomUser = _mapper.Map<ChatRoomUsers>(chatRoomUserCreate);
            await _chatRoomUsersRepository.CreateAsync(chatRoomUser);
            await _chatRoomUsersRepository.SaveAsync(); // assuming you have a SaveAsync method in your repository
            return Ok($"Chat room user {chatRoomUser.Id} added");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteChatRoomUserAsync(Guid id)
        {
            var existingChatRoomUser = await _chatRoomUsersRepository.GetAsync(id);
            if (existingChatRoomUser == null)
            {
                return NotFound("Chat room user not found");
            }

            await _chatRoomUsersRepository.DeleteAsync(id);
            await _chatRoomUsersRepository.SaveAsync(); // assuming you have a SaveAsync method in your repository
            return Ok($"Chat room user {id} deleted");
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateChatRoomUserAsync(Guid id, ChatRoomUsersUpdate chatRoomUserUpdate)
        {
            var existingChatRoomUser = await _chatRoomUsersRepository.GetAsync(id);
            if (existingChatRoomUser == null)
            {
                return NotFound("Chat room user not found");
            }

            _mapper.Map(chatRoomUserUpdate, existingChatRoomUser);
            await _chatRoomUsersRepository.UpdateAsync(existingChatRoomUser);
            await _chatRoomUsersRepository.SaveAsync(); // assuming you have a SaveAsync method in your repository

            return Ok($"Chat room user {id} updated");
        }
    }
}
