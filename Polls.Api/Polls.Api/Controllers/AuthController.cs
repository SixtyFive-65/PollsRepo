using Microsoft.AspNetCore.Mvc;
using Polls.Api.Models;
using Polls.Api.Service.User;

namespace Polls.Api.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService userService;
        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserModel user)
        {
            var registerUser = await userService.RegisterUser(user);

            if (registerUser)
            {
                return Ok(new { registerUser, Message = "User Successfully registered" });
            }
            else
            {
                return BadRequest(new { registerUser, Message = "Failed to register user" });
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> GetToken([FromBody]UserLoginModel user)
        {
            var Token = await userService.GetToken(user);

            if (!string.IsNullOrEmpty(Token))
            {
                return Ok(new { Token });

            }

            return Unauthorized(new { Token, Message = "Failed to retreive Token" });
        }
    }
}
