using Application.Handlers.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IApplicationUserHandler _userHandler;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IApplicationUserHandler applicationUserHandler, ILogger<AuthController> logger)
        {
            _userHandler = applicationUserHandler;
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return Redirect("/");
            }
            else
            {
                return View();
            }
        }

        public IActionResult SignUp()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return Redirect("/");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginUserViewModel user)
        {
            try
            {
                _logger.LogInformation($"Attempting to log in user {user.Login}.");
                
                User registeredUser = _userHandler.OnUserLogin(user.Login, user.Password);

                var claims = new List<Claim>
                {
                    new Claim("Id", registeredUser.Id.ToString()),
                    new Claim(ClaimTypes.Role, "Administrator"),
                    new Claim(ClaimTypes.Name, registeredUser.Login)
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                _logger.LogInformation($"User {user.Login} successfully logged in.");

                return RedirectToAction("Index", "Home");
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogWarning($"Login attempt for user {user.Login} failed: {ex.Message}");

                ModelState.AddModelError("Login", ex.Message);
                return View("Index", user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while attempting to log in user {user.Login}: {ex.Message}");

                ModelState.AddModelError("Login", "An error occurred while logging in.");
                return View("Index", user);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser(CreateUserViewModel user)
        {
            try
            {
                _logger.LogInformation($"Attempting to create user {user.Login}.");

                User registeredUser = _userHandler.OnUserSignUp(user.Login, user.Password);

                var claims = new List<Claim>
                {
                    new Claim("Id", registeredUser.Id.ToString()),
                    new Claim(ClaimTypes.Role, "Administrator"),
                    new Claim(ClaimTypes.Name, registeredUser.Login)
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                _logger.LogInformation($"User {user.Login} successfully registered and logged in.");

                return RedirectToAction("Index", "Home");
            }
            catch(ArgumentException ex)
            {
                _logger.LogWarning($"User registration attempt for user {user.Login} failed: {ex.Message}");

                ModelState.AddModelError("Login", ex.Message);
                return View("SignUp", user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while attempting to create user: {ex.Message}");

                ModelState.AddModelError("Login", "An unexpected error occurred.");
                return View("Index", user);
            }
        }

        [Authorize]
        public async Task<IActionResult> LogOut() {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            _logger.LogInformation($"User {User.Identity!.Name} successfully logged out.");
            return RedirectToAction("Index", "Auth");
        }
    }
}
