using AutoMapper;
using Forum.BL.DTOs.Topics;
using Forum.BL.DTOs.Users;
using Forum.Core.Entities;
using System.Linq;

namespace Forum.BL.Mapping
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration Configure()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<CreateUserDTO, User>();
                    cfg.CreateMap<User, UserDTO>();
                    cfg.CreateMap<UpdateUserDTO, User>();
                    cfg.CreateMap<CreateTopicDTO, Topic>();
                    cfg.CreateMap<Topic, TopicDTO>();
                   
                });
            return config;
        }

    }
}

   