using AutoMapper;
using LocalChat.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Server.Infrastructure.Helper
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
