using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalChat.Core.Entities
{
    public class ChatRoom : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Message>? Messages { get; set; }
    }
}
