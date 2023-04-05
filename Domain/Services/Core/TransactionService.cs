using Domain.Models;
using Domain.Repositories;
using Domain.Services.Interfaces;

namespace Domain.Services.Core
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public void AddTransaction(Transaction transaction)
        {
            _transactionRepository.addTransaction(transaction);
        }

        public List<Transaction> GetUserTransactions(int UserId)
        {
            return _transactionRepository.GetAllTransactions().Where(t => t.UserId == UserId).ToList();
        }

        public List<TransactionCategory> GetUserTransactionsDividedIntoCategories(int UserId, bool IsIncome)
        {
            List<Transaction> transactions = _transactionRepository.GetAllTransactions();

            List<TransactionCategory> categories = transactions
                .Where(t => t.IsIncome == IsIncome && t.UserId == UserId)
                .GroupBy(t => t.Category)
                .Select(g => new TransactionCategory
                {
                    Name = g.Key,
                    Value = g.Sum(t => t.Value)
                })
                .ToList();

            return categories;
        }
    }
}
