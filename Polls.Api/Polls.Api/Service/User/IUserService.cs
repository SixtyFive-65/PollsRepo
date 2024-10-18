﻿using Polls.Api.Models;

namespace Polls.Api.Service.User
{
    public interface IUserService
    {
        Task<bool> RegisterUser(RegisterUserModel user);
        Task<string> GetToken(UserLoginModel user);
    }
}
