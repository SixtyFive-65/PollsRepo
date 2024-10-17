using Polls.Api.Models;
using Polls.Api.Repository.User;

namespace Polls.Api.Service.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<string> GetToken(UserModel user)
        {
            return await userRepository.GetToken(user);
        }

        public Task<bool> RegisterUser(UserModel user)
        {
            return userRepository.RegisterUser(user);
        }
    }
}
