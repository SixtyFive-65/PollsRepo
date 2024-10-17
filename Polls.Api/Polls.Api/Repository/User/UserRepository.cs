using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Polls.Api.Data;
using Polls.Api.Data.DomainModels;
using Polls.Api.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Polls.Api.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthDbContext authDbContext;
        private readonly IConfiguration configuration;

        public UserRepository(AuthDbContext authDbContext, IConfiguration configuration)
        {
            this.authDbContext = authDbContext;
            this.configuration = configuration;
        }
        public async Task<string> GetToken(UserModel user)
        {
            var dbUser = await authDbContext.ApplicationUsers.FirstOrDefaultAsync(u => u.Username == user.Username && u.Password == user.Password);

            if (dbUser == null)
            {
                return "";
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.NameIdentifier, dbUser.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task<bool> RegisterUser(UserModel user)
        {
            var dbUser = await authDbContext.ApplicationUsers.FirstOrDefaultAsync(u => u.Username.ToLowerInvariant() == user.Username.ToLowerInvariant());

            if (dbUser == null)
            {
                var applicationUser = new ApplicationUser
                {
                    Username = user.Username,
                    Password = user.Password  //Encryp
                };

                authDbContext.ApplicationUsers.Add(applicationUser);
            }

            var saveResult = await authDbContext.SaveChangesAsync();

            if (saveResult > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
