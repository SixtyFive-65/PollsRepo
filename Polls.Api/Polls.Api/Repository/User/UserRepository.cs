using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Polls.Api.Data;
using Polls.Api.Data.DomainModels;
using Polls.Api.Models;
using Serilog;
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
            var token = string.Empty;
            try
            {
                var dbUser = await authDbContext.ApplicationUsers.FirstOrDefaultAsync(u => u.Username == user.Username);

                if (dbUser == null)
                {
                    return "";
                }

                if (BCrypt.Net.BCrypt.Verify(user.Password, dbUser.Password))
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new[]
                        {
                             new Claim(ClaimTypes.NameIdentifier, dbUser.Id.ToString()),
                             new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // Add a unique identifier
                        }),
                        Expires = DateTime.UtcNow.AddMinutes(30),
                        Issuer = configuration["Jwt:Issuer"], // Include the issuer
                        Audience = configuration["Jwt:Audience"], // Include the audience
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var generatedToken = tokenHandler.CreateToken(tokenDescriptor);

                    Log.Information($"Successfuly generated token for {user.Username}");

                    token = tokenHandler.WriteToken(generatedToken);
                }

                return token;
            }
            catch (Exception ex)
            {
                Log.Error($"Failed to generate token for {user.Username} - {ex.Message}", ex);

                return "";
            }
        }

        public async Task<bool> RegisterUser(UserModel user)
        {
            try
            {
                var dbUser = await authDbContext.ApplicationUsers.FirstOrDefaultAsync(u => u.Username == user.Username);

                if (dbUser == null)
                {
                    var applicationUser = new ApplicationUser
                    {
                        Username = user.Username,
                        Password = BCrypt.Net.BCrypt.HashPassword(user.Password)
                    };

                    authDbContext.ApplicationUsers.Add(applicationUser);
                }

                var saveResult = await authDbContext.SaveChangesAsync();

                if (saveResult > 0)
                {
                    Log.Information($"Successfuly registered {user.Username}");

                    return true;
                }
                else
                {
                    Log.Error($"Failed to register {user.Username}");

                    return false;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);

                return false;
            }
        }
    }
}
