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
                var token = await userService.GetToken(new UserLoginModel
                {
                    Username = user.Username,
                    Password = user.Password
                });

                return Ok(new { token });
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

            var token = await userService.GetToken(user);

            if (!string.IsNullOrEmpty(token))
            {
                return Ok(new { token });

            }

            return Unauthorized(new { token });
        }
    }
}
