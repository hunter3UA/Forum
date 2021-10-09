using AutoMapper;
using Forum.BL.DTOs;
using Forum.Core.Entities;

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
                   
                });
            return config;
        }

    }
}

   