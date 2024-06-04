using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalChat.Core.Entities
{
    public class MessegeUsers : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public int number { get; set; }

    }
}
