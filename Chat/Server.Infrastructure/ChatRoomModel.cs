using LocalChat.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure
{
    public class ChatRoomModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Message>? Messages { get; set; }

    }
    public class ChatRoomCreate
    {
        public string Name { get; set; }
        public List<Message>? Messages { get; set; }
    }
    public class ChatRoomUpdate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Message>? Messages { get; set; }
    }
}
