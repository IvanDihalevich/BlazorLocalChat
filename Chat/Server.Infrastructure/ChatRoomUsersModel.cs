using LocalChat.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure
{
    public class ChatRoomUsersModel
    {
        public Guid Id { get; set; }
        public User user { get; set; }
        public ChatRoom chatRoomId { get; set; }

    }
    public class ChatRoomUsersCreate
    {
        public User user { get; set; }
        public ChatRoom chatRoomId { get; set; }
    }
    public class ChatRoomUsersUpdate
    {
        public Guid Id { get; set; }
        public User user { get; set; }
        public ChatRoom chatRoomId { get; set; }
    }
}
