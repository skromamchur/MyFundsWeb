using Microsoft.AspNetCore.Mvc;
using WebUI.Models;
using Application.Handlers.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace WebUI.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private readonly IApplicationTransactionHandler _transactionHandler;

        public TransactionController(IApplicationTransactionHandler transactionHandler)
        {
            _transactionHandler = transactionHandler;
        }

        public IActionResult Index()
        {
            var userId = Convert.ToInt32(User.FindFirstValue("Id")); 
            var userTransactions = _transactionHandler.GetUserTransactions(userId);
            var viewModel = new TransactionViewModel
            {
                Transactions = userTransactions
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateIncome(TransactionViewModel model)
        {
            _transactionHandler.OnCreateTransaction(model.Value, model.Category, true, model.Currency, Convert.ToInt32(User.FindFirstValue("Id")));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CreateExpend(TransactionViewModel model)
        {
            _transactionHandler.OnCreateTransaction(model.Value, model.Category, false, model.Currency, Convert.ToInt32(User.FindFirstValue("Id")));
            return RedirectToAction("Index");
        }
    }
}
