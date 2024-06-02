using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalChat.Core.Entities
{
    public class MessedgeUsers : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public List<Message>? MessageId { get; set; }
        public User Receiver { get; set; }

    }
}
