using LocalChat.Core.Entities;
using LocalChat.Reposetory.CommonR;
using System;

namespace LocalChat.Reposetory.Messages
{
    public interface IMessageRepository : IRepository<Message, Guid>
    {
    }
}
