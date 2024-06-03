using LocalChat.Core.Context;
using LocalChat.Core.Entities;
using LocalChat.Reposetory.CommonR;
using Microsoft.EntityFrameworkCore;
using Server.Infrastructure.Helper;

Repository<ChatRoom, Guid> _chatroomRepository;
Repository<ChatRoomUsers, Guid> _chatRoomUsersRepository;
Repository<Message, Guid> _messageRepository;
Repository<MessegeUsers, Guid> _messegeUsersRepository;
Repository<User, Guid> _userRepository;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ChatContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(typeof(MappingProfiles));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));


builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient", builder =>
    {
        builder.WithOrigins("https://localhost:7044")
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials();
    });
});
var app = builder.Build();
app.UseCors("AllowBlazorClient");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
