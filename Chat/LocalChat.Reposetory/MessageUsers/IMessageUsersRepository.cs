using LocalChat.Core.Entities;
using LocalChat.Reposetory.CommonR;
using System;

namespace LocalChat.Reposetory.MessageUsers
{
    public interface IMessageUsersRepository : IRepository<MessegeUsers, Guid>
    {
    }
}
