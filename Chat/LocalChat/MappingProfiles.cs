using AutoMapper;
using LocalChat.Core.Entities;
using Server.Infrastructure;

namespace LocalChat
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ChatRoom, ChatRoomModel>().ReverseMap();
            CreateMap<ChatRoom, ChatRoomCreate>().ReverseMap();
            CreateMap<ChatRoom, ChatRoomUpdate>().ReverseMap();

            CreateMap<ChatRoomUsers, ChatRoomUsersModel>().ReverseMap();
            CreateMap<ChatRoomUsers, ChatRoomUsersCreate>().ReverseMap();
            CreateMap<ChatRoomUsers, ChatRoomUsersUpdate>().ReverseMap();

            CreateMap<Message, MessageModel>().ReverseMap();
            CreateMap<Message, MessageCreate>().ReverseMap();
            CreateMap<Message, MessageUpdate>().ReverseMap();

            CreateMap<MessegeUsers, MessegeUsersModel>().ReverseMap();
            CreateMap<MessegeUsers, MessegeUsersCreate>().ReverseMap();
            CreateMap<MessegeUsers, MessegeUsersUpdate>().ReverseMap();

            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<User, UserCreate>().ReverseMap();
            CreateMap<User, UserUpdate>().ReverseMap();
        }

    }
}
