using Domain.Models;

namespace Application.Handlers.Interfaces
{
    public interface IApplicationTransactionHandler
    {
        public void OnCreateTransaction(decimal value, string category, bool isIncome, string currency, int userId);
        
        public List<Transaction> GetUserTransactions(int UserId);
        public List<TransactionCategory> GetTransactionCategories(int UserId, bool IsIncome);
    }
}
