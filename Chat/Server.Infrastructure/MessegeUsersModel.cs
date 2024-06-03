using LocalChat.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure
{
    public class MessegeUsersModel
    {
        public Guid Id { get; set; }
        public List<Message>? MessageId { get; set; }
        public User Receiver { get; set; }

    }
    public class MessegeUsersCreate
    {
        public List<Message>? MessageId { get; set; }
        public User Receiver { get; set; }
    }
    public class MessegeUsersUpdate
    {
        public Guid Id { get; set; }
        public List<Message>? MessageId { get; set; }
        public User Receiver { get; set; }
    }
}
