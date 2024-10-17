using Polls.Api.Models;

namespace Polls.Api.Repository.User
{
    public interface IUserRepository
    {
        Task<bool> RegisterUser(UserModel user);
        Task<string> GetToken(UserModel user);
    }
}
