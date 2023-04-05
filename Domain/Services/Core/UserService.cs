using Domain.Models;
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

        public User FindUserByCredentials(string login, string password)
        {
            List<User> users = _userRepository.GetAllUsers();
            var foundedUser =  users.FirstOrDefault(u => u.Login == login && u.Password == password);

            if(foundedUser == null)
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }

           return foundedUser;
        }

        public User RegisterUser(string login, string password)
        {
            var existingUser = _userRepository.GetAllUsers().FirstOrDefault(u => u.Login == login);
            
            if (existingUser != null)
            {
                throw new ArgumentException("User with the same login already exists");
            }

            return _userRepository.AddUser(new Models.User() { 
                Login = login,
                Password = password
            });
        }
    }
}
