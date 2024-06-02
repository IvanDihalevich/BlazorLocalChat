using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalChat.Core.Entities
{
    public class ChatRoomUsers
    {
        public Guid Id { get; set; }
        public User user { get; set; }
        public ChatRoom chatRoomId { get; set; }
    }
}
