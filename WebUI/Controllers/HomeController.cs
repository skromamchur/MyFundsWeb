using Application.Handlers.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IApplicationTransactionHandler _transactionHandler;

        public HomeController(IApplicationTransactionHandler transactionHandler) {
            _transactionHandler = transactionHandler;
        }

        public IActionResult Index()
        {
            var userId = Convert.ToInt32(User.FindFirstValue("Id"));
            var incomeUserTransactions = _transactionHandler.GetTransactionCategories(userId, true);
            var expendUserTransactions = _transactionHandler.GetTransactionCategories(userId, false);

            return View(new DashboardViewModel { 
                incomeTransactions = incomeUserTransactions,
                expendTransactions = expendUserTransactions
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}