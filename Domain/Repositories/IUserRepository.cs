using Domain.Models;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        public void AddUser(User user);
    }
}
