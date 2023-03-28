using Application.Handlers.Interfaces;
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

        public void OnUserSignUp(string login, string password)
        {
            _userService.RegisterUser(login, password);
        }
    }
}
