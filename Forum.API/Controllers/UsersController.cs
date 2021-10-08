using Forum.BL.DTOs;
using Forum.BL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService=userService;
        }


        // GET api/v1/<UsersController>
        [HttpPost]
        public async Task<CreateUserDTO>  Get(int userID)
        {
            return null;
        }
    }
}
