using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Enteties
{
    public class UserDB
    {
        public UserDB(string login, string password)
        {
            this.Login = login;
            this.Password = password;
        }

        [Key]
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}
