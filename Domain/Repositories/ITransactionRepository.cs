using Domain.Models;

namespace Domain.Repositories
{
    public interface ITransactionRepository
    {
        public void addTransaction(Transaction transaction);

        public List<Transaction> GetUserTransactions(int UserId);

        public List<Transaction> GetAllTransactions();
    }
}
