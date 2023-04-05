using Domain.Models;
using Domain.Repositories;
using Infrastructure.Enteties;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        readonly private Context _context;

        public TransactionRepository(string connectionString)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            _context = new Context(connectionString);
        }

        public void addTransaction(Domain.Models.Transaction transaction)
        {
            _context.Transactions.Add(new TransactionDB()
            {
                Value = transaction.Value,
                Category = transaction.Category,
                IsIncome = transaction.IsIncome,
                Date = DateTime.UtcNow,
                Currency = transaction.Currency,
                User = _context.Users.Find(transaction.UserId)!
            });
            _context.SaveChanges();
        }

        public List<Transaction> GetUserTransactions(int UserId)
        {
            var user = _context.Users
                       .Include(u => u.Transactions)
                       .FirstOrDefault(u => u.Id == UserId);

            List<TransactionDB> transactionDBs = user.Transactions.ToList();

            var transactions = new List<Transaction>();

            foreach (var transactionDB in transactionDBs)
            {
                var transaction = new Transaction() {
                   Value = transactionDB.Value,
                   Category = transactionDB.Category,
                   IsIncome = transactionDB.IsIncome,
                   Date =  transactionDB.Date,
                   Currency =  transactionDB.Currency
                };
                transactions.Add(transaction);
            }

            return transactions;
        }

        public List<Transaction> GetAllTransactions() {
            List<TransactionDB> transactionDBs = _context.Transactions.Include(t => t.User).ToList();

            var transactions = new List<Transaction>();

            foreach (var transactionDB in transactionDBs)
            {
                var transaction = new Transaction()
                {
                    Value = transactionDB.Value,
                    Category = transactionDB.Category,
                    IsIncome = transactionDB.IsIncome,
                    Date = transactionDB.Date,
                    Currency = transactionDB.Currency,
                    UserId = transactionDB.User.Id
                };
                transactions.Add(transaction);
            }

            return transactions;
        }
    }
}
