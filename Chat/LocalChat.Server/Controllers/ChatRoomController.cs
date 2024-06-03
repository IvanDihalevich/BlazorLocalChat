using LocalChat.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using LocalChat.Reposetory.CommonR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalChat.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatRoomController : ControllerBase
    {
        private readonly Repository<ChatRoom, Guid> _chatroomRepository;
        private readonly Repository<ChatRoomUsers, Guid> _chatRoomUsersRepository;
        private readonly Repository<Message, Guid> _messageRepository;
        private readonly Repository<MessegeUsers, Guid> _messegeUsersRepository;
        private readonly Repository<User, Guid> _userRepository;

        public ChatRoomController(
            Repository<ChatRoom, Guid> chatroomRepository,
            Repository<ChatRoomUsers, Guid> chatRoomUsersRepository,
            Repository<Message, Guid> messageRepository,
            Repository<MessegeUsers, Guid> messegeUsersRepository,
            Repository<User, Guid> userRepository)
        {
            _chatroomRepository = chatroomRepository;
            _chatRoomUsersRepository = chatRoomUsersRepository;
            _messageRepository = messageRepository;
            _messegeUsersRepository = messegeUsersRepository;
            _userRepository = userRepository;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllChatRoomsAsync()
        {
            var chatRooms = await _chatroomRepository.GetAllAsync();
            return Ok(chatRooms);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddChatRoomAsync(ChatRoom chatRoom)
        {
            await _chatroomRepository.CreateAsync(chatRoom);
            return Ok($"Chat room {chatRoom.Id} added");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteChatRoomAsync(Guid id)
        {
            await _chatroomRepository.DeleteAsync(id);
            return Ok($"Chat room {id} deleted");
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateChatRoomAsync(Guid id, ChatRoom chatRoom)
        {
            var existingChatRoom = await _chatroomRepository.GetAsync(id);
            if (existingChatRoom == null)
            {
                return NotFound("Chat room not found");
            }

            existingChatRoom.Name = chatRoom.Name; // Update other properties as needed

            await _chatroomRepository.UpdateAsync(existingChatRoom);

            return Ok($"Chat room {id} updated");
        }
    }
}
