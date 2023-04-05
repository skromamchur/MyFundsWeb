using Domain.Models;

namespace Application.Handlers.Interfaces
{
    public interface IApplicationUserHandler
    {
        public User OnUserSignUp(string login, string password);
        public User OnUserLogin(string login, string password);
    }
}
