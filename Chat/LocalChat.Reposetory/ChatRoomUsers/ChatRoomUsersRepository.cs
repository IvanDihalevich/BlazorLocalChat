using LocalChat.Core.Context;
using LocalChat.Core.Entities;
using LocalChat.Reposetory.CommonR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalChat.Reposetory.ChatRoomUsers
{
    public class ChatRoomUserRepository : Repository<ChatRoom, Guid>, IChatRoomUsersRepository
    {
        public ChatRoomUserRepository(ChatContext context) : base(context)
        {
        }
    }
}

