using LocalChat.Core.Context;
using LocalChat.Core.Entities;
using LocalChat.Reposetory.CommonR;
using LocalChat.Repository.Users;
using System;

namespace LocalChat.Repository.UserManagement
{
    public class UsersRepository : Repository<User, Guid>, IUsersRepository
    {
        public UsersRepository(ChatContext context) : base(context)
        {
        }
    }
}
