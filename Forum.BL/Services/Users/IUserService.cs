using Forum.BL.DTOs.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.BL.Services
{
    public interface IUserService
    {
        Task<UserDTO> AddNewUser(CreateUserDTO createUserDTO);
        Task<UserDTO> GetUserByID(int userID);
        Task<UserDTO> GetUserByNickName(string nickName);
        Task<List<UserDTO>> GetUsersByTopicID(int topicID);
        Task<List<UserDTO>> GetUsersByTopicName(string topicName);
        Task<UserDTO> UpdateRole(int userID, string newRole);
        Task<List<UserDTO>> GetBannedUsers();
        Task<UserDTO> DeleteUser(int userID);
        Task<bool> UpdateUser(UpdateUserDTO updateUserDTO);
    }
}

