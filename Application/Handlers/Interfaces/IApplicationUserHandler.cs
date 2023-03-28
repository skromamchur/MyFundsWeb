using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Interfaces
{
    public interface IApplicationUserHandler
    {
        void OnUserSignUp(string login, string password);
    }
}
