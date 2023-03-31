using Domain.Models;
using Domain.Repositories;
using Infrastructure.Enteties;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly private Context _context;

        public UserRepository(string connectionString)
        {
            if(connectionString == null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            _context = new Context(connectionString);
        }

        public void AddUser(Domain.Models.User user)
        {
            _context.Users.Add(new Enteties.UserDB(user.Login, user.Password));
            _context.SaveChanges();
        }
    }
}
