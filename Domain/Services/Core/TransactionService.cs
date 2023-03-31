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
            return _transactionRepository.GetUserTransactions(UserId); 
        }
    }
}
