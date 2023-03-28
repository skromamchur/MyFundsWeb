using Application.Handlers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IApplicationUserHandler _userHandler;

        public AccountController(IApplicationUserHandler applicationUserHandler)
        {
            _userHandler = applicationUserHandler;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(CreateUserViewModel user)
        {
            _userHandler.OnUserSignUp(user.Login, user.Password);

            return Ok();
        }
    }
}
