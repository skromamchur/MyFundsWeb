using Domain.Models;

namespace Domain.Services.Interfaces
{
    public interface IUserService
    {
        public User RegisterUser(string login, string password);
        public User FindUserByCredentials(string login, string password);
    }
}
