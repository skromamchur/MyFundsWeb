using Application.Handlers.Interfaces;
using Domain.Models;
using Domain.Services.Interfaces;

namespace Application.Handlers.Core
{
    internal class ApplicationTransactionHandler : IApplicationTransactionHandler
    {
        private readonly ITransactionService _transactionService;
        public ApplicationTransactionHandler(ITransactionService transactionService) {
            _transactionService = transactionService;
        }

        public List<TransactionCategory> GetTransactionCategories(int UserId, bool IsIncome)
        {
            return _transactionService.GetUserTransactionsDividedIntoCategories(UserId, IsIncome);
        }

        public List<Transaction> GetUserTransactions(int UserId)
        {
           return _transactionService.GetUserTransactions(UserId); 
        }

        public void OnCreateTransaction(decimal value, string category, bool isIncome, string currency, int userId) {
            _transactionService.AddTransaction(new Domain.Models.Transaction() { 
                Value = value,
                Category = category,
                IsIncome = isIncome,
                Currency = currency,
                UserId = userId
            });
        }
    }
}
