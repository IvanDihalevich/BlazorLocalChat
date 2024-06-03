using LocalChat.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }

    }
    public class UserCreate
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
    }
    public class UserUpdate
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
    }
}
