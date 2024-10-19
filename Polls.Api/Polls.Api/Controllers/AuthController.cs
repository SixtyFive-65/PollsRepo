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
            if (!ModelState.IsValid)
            {
                return BadRequest(new { user });
            }
            var registerUser = await userService.RegisterUser(user);

            if (registerUser)
            {
                return Ok(new { registerUser });
            }
            else
            {
                return BadRequest(new { registerUser });
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> GetToken([FromBody]UserLoginModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { user });
            }

            var Token = await userService.GetToken(user);

            if (!string.IsNullOrEmpty(Token))
            {
                return Ok(new { Token });

            }

            return Unauthorized(new { Token });
        }
    }
}
