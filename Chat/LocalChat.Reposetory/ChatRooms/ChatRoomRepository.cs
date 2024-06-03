using LocalChat.Core.Context;
using LocalChat.Core.Entities;
using LocalChat.Reposetory.CommonR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalChat.Reposetory.ChatRooms
{
    public class ChatRoomRepository : Repository<ChatRoom, Guid>, ICityRepository
    {
        public ChatRoomRepository(ChatContext context) : base(context)
        {
        }
    }
}
