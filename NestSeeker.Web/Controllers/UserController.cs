using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NestSeeker.Data.Model;
using NestSeeker.Service;

namespace NestSeeker.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }
        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            //UserService service = new UserService();
            return Ok(_userService.GetAllUser());
        }
        [HttpPost("adduser")]
        public IActionResult AddUser(User user)
        {
            //UserService service = new UserService();
            return Ok(_userService.AddUser(user));
        }
        [HttpPut("updateuser")]
        public IActionResult UpdateUser(User user)
        {
            //UserService service = new UserService();
            return Ok(_userService.UpdateUser(user));
        }
        [HttpPut("deleteuser/{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            //UserService service = new UserService();
            return Ok(_userService.DeleteUser(userId));
        }
    }
}
