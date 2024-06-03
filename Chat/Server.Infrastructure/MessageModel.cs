using LocalChat.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure
{
    public class MessageModel
    {
        public Guid Id { get; set; }
        public Guid SenderId { get; set; }
        public string Text { get; set; }
        public DateTime SendTime { get; set; } = DateTime.Now;
        public Guid ChatRoomId { get; internal set; }
        public Guid MessedgeUsersId { get; internal set; }
        public User Sender { get; set; }

    }
    public class MessageCreate
    {
        public Guid SenderId { get; set; }
        public string Text { get; set; }
        public DateTime SendTime { get; set; } = DateTime.Now;
        public Guid ChatRoomId { get; internal set; }
        public Guid MessedgeUsersId { get; internal set; }
        public User Sender { get; set; }
    }
    public class MessageUpdate
    {
        public Guid Id { get; set; }
        public Guid SenderId { get; set; }
        public string Text { get; set; }
        public DateTime SendTime { get; set; } = DateTime.Now;
        public Guid ChatRoomId { get; internal set; }
        public Guid MessedgeUsersId { get; internal set; }
        public User Sender { get; set; }
    }
}
