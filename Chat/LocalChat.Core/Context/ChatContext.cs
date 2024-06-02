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
        public DbSet<MessedgeUsers> messedgeUsers => Set<MessedgeUsers>();
        public DbSet<ChatRoomUsers> ChatRoomUsers => Set<ChatRoomUsers>();

        public ChatContext(DbContextOptions<ChatContext> options)
         : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            // Встановлення відношення між `Message` і `User`
            builder.Entity<Message>()
                .HasOne(m => m.Sender)  // Відношення один до одного
                .WithMany()  // Користувач може мати багато повідомлень
                .HasForeignKey(m => m.SenderId)  // Вказуємо, що `SenderId` - це зовнішній ключ
                .OnDelete(DeleteBehavior.Restrict);  // Опція на випадок видалення користувача

        }
    }
