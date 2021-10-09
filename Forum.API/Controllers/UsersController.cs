using Forum.BL.DTOs;
using Forum.BL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService=userService;
        }

        // POST api/<UsersController>/AddUser/
        [HttpPost]
        public async Task<UserDTO> AddUser([FromBody]CreateUserDTO createUserDTO)
        {
            return await _userService.AddNewUser(createUserDTO);
        }

        // GET api/<UsersController>/GetUserByID/{userID}      
        [HttpGet("{userID}")]      
        public async Task<UserDTO> GetUserByID(int userID)
        {
            return await _userService.GetUserByID(userID);
        }

        //GET api/<UsersController>/GetByTopicID/{topicID}
        [HttpGet("{topicID}")]
        public async Task<List<UserDTO>> GetByTopicID(int topicID)
        {
            return await _userService.GetUsersByTopicID(topicID);
        }

        // GET api/<UsersController/GetBannedUsers
        [HttpGet]
        public async Task<List<UserDTO>> GetBannedUsers()
        {
            return await _userService.GetBannedUsers();
        }

        // PUT api/<UsersController/UpdateUser
        [HttpPut]
        public async Task<bool> UpdateUser([FromBody] UpdateUserDTO updateUserDTO)
        {
            return await _userService.UpdateUser(updateUserDTO);
        }

        // PUT api/<UsersController>/UpdateUserRole/{userID,newRole}
        [HttpPut("{userID,newRole}")]
        public async Task<UserDTO> UpdateUserRole(int userID, string newRole)
        {
            return await _userService.UpdateRole(userID, newRole);
        }

        // PUT api/v1/<UsersController>/DeleteUser/{userID}
        [HttpPut("{userID}")]
        public async Task<UserDTO> DeleteUser(int userID)
        {
            return await _userService.DeleteUser(userID);
        }
    }
}
