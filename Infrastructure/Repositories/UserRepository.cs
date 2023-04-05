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

        public User AddUser(Domain.Models.User user)
        {
            var userDb = new Enteties.UserDB(user.Login, user.Password);
            _context.Users.Add(userDb);
            _context.SaveChanges();

            return new User()
            {
                Login = userDb.Login,
                Password = userDb.Password,
                Id = userDb.Id,
            };
        }

        public List<User> GetAllUsers()
        {
            List<UserDB> userDbs = _context.Users.ToList();

            List<User> users = userDbs.Select(u => new User()
            {
                Id = u.Id,
                Login = u.Login,
                Password = u.Password,
            }).ToList();
            
            return users;
        }
    }
}
