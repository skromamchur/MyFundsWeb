using Domain.Models;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        public User AddUser(User user);

        public List<User> GetAllUsers();
    }
}
