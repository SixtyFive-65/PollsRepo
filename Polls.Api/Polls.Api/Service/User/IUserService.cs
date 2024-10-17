using Polls.Api.Models;

namespace Polls.Api.Service.User
{
    public interface IUserService
    {
        Task<bool> RegisterUser(UserModel user);
        Task<string> GetToken(UserModel user);
    }
}
