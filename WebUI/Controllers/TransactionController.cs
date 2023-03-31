using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using WebUI.Models;
using Application.Handlers.Interfaces;

namespace WebUI.Controllers
{
    public class TransactionController : Controller
    {
        private readonly IApplicationTransactionHandler _transactionHandler;

        public TransactionController(IApplicationTransactionHandler transactionHandler)
        {
            _transactionHandler = transactionHandler;
        }

        public IActionResult Index()
        {
            var userId = 1; // hardcoded for testing
            var userTransactions = _transactionHandler.GetUserTransactions(userId);
            var viewModel = new TransactionViewModel
            {
                Transactions = userTransactions,
                UserId = userId
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(TransactionViewModel model)
        {
            _transactionHandler.OnCreateTransaction(model.Value, model.Category, model.IsIncome, DateTime.UtcNow, model.Currency, model.UserId);
            return RedirectToAction("Index");
        }
    }
}
