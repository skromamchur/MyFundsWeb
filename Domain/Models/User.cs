using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        public User(string Login, string Password)
        {
            this.Login = Login;
            this.Password = Password;
        }

        public string Login { get; set; }
        public string Password { get; set; }
    }
}
