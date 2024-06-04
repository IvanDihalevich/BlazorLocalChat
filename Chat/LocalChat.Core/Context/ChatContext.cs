using LocalChat.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LocalChat.Core.Context
{
    public class ChatContext : DbContext
    {
        public DbSet<ChatRoom> ChatRooms => Set<ChatRoom>();
        public DbSet<Message> Messages => Set<Message>();
        public DbSet<MessegeUsers> messedgeUsers => Set<MessegeUsers>();
        public DbSet<ChatRoomUsers> ChatRoomUsers => Set<ChatRoomUsers>();

        public ChatContext(DbContextOptions<ChatContext> options)
         : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

        }
    }
}