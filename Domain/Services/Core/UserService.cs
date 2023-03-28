using Domain.Repositories;
using Domain.Services.Interfaces;

namespace Domain.Services.Core
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) {
            _userRepository = userRepository;            
        }

        public void RegisterUser(string login, string password)
        {
            _userRepository.AddUser(new Models.User(login, password));
        }
    }
}
