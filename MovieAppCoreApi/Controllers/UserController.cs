using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieBussiness.Services;
using MovieEntity.Models;
using System.Collections.Generic;

namespace MovieAppCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] User users)
        {
            _userService.Register(users);
            return Ok("Register successfully!!");
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] User users)
        {
            User user = _userService.Login(users);
            if (user != null)
                return Ok("Login success!!");
            else
                return NotFound();
        }
    }
}
