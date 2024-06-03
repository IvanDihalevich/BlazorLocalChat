using LocalChat.Core.Entities;
using LocalChat.Reposetory.CommonR;
using System;

namespace LocalChat.Repository.Users 
{
    public interface IUsersRepository : IRepository<User, Guid>
    {
    }
}
