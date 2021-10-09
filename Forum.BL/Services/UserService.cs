using AutoMapper;
using Forum.BL.DTOs;
using Forum.BL.Mapping;
using Forum.Core.Entities;
using Forum.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Forum.BL.Services.PasswordService;

namespace Forum.BL.Services
{
    public class UserService:IUserService
    {
        private IMapper _mapper;
        public UserService()
        {
            _mapper = AutoMapperConfiguration.Configure().CreateMapper();
        }

        public async Task<UserDTO> AddNewUser(CreateUserDTO createUserDTO)
        {
            User newUser = new User();
            if (createUserDTO != null)
            {
                newUser.NickName = createUserDTO.NickName;
                newUser.EmailAddress = createUserDTO.EmailAddress;
                newUser.IsEnabled = true;                      
                Salted_Hash salted_Hash = PasswordService.Security.HashHMACSHA1.CreateSaltedHash(createUserDTO.Password);
                newUser.PasswordHash = salted_Hash.Hash;
                newUser.PasswordSalt = salted_Hash.Salt;
                newUser.RegistredAt = DateTime.Now;
                User addedUser = await ForumRepository.UsersRepository.AddNewUser(newUser);
                UserDTO addedUserDTO = _mapper.Map<UserDTO>(addedUser);
                return addedUserDTO;
            }
            else{ return new UserDTO(); }
            
        }
        public async Task<UserDTO> GetUserByID(int userID)
        {
            User userToUpdate = await ForumRepository.UsersRepository.GetUserByID(userID);
            return _mapper.Map<UserDTO>(userToUpdate);
        }
        public async Task<UserDTO> GetUserByNickName(string nickName)
        {
            User userToUpdate = await ForumRepository.UsersRepository.GetUserByNickName(nickName);
            return _mapper.Map<UserDTO>(userToUpdate);
        }
        public async Task<List<UserDTO>> GetUsersByTopicID(int topicID)
        {
            List<User> usersToSearch = await ForumRepository.UsersRepository.AllByTopicID(topicID);
            return _mapper.Map<List<UserDTO>>(usersToSearch);
        }
        public async Task<List<UserDTO>> GetUsersByTopicName(string topicName)
        {
            List<User> usersToSearch = await ForumRepository.UsersRepository.AllByTopicName(topicName);
            return _mapper.Map<List<UserDTO>>(usersToSearch);
        }
        public async Task<UserDTO> UpdateRole(int userID,string newRole)
        {
            User userToUpdate=await ForumRepository.UsersRepository.UpdateRole(userID,newRole);
            return _mapper.Map<UserDTO>(userToUpdate);
        }       
        public async Task<bool> UpdateUser(UpdateUserDTO updateUserDTO)
        {
            User userToUpdate = _mapper.Map<User>(updateUserDTO);
            return  await ForumRepository.UsersRepository.UpdateUser(userToUpdate);
        }
        public async Task<List<UserDTO>> GetBannedUsers()
        {
            List<User> bannedUsers = await ForumRepository.UsersRepository.GetBannedUsers();
            return _mapper.Map<List<UserDTO>>(bannedUsers);
        }
        public async Task<UserDTO> DeleteUser(int userID)
        {
            User userToDelete = await ForumRepository.UsersRepository.DeleteByID(userID);
            return _mapper.Map<UserDTO>(userToDelete);
        }


    }
}
