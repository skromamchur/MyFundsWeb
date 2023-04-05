using Application.Handlers.Interfaces;
using Domain.Models;
using Domain.Services.Interfaces;

namespace Application.Handlers.Core
{
    internal class ApplicationUserHandler : IApplicationUserHandler
    {
        private readonly IUserService _userService;

        public ApplicationUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public User OnUserSignUp(string login, string password)
        {
            return _userService.RegisterUser(login, password);
        }

        public User OnUserLogin(string login, string password)
        {
            return _userService.FindUserByCredentials(login, password);
        }
    }
}
