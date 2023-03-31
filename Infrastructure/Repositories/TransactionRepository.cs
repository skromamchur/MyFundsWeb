using Domain.Models;
using Domain.Repositories;
using Infrastructure.Enteties;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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
                User = _context.Users.Find(1)!
            });
            _context.SaveChanges();
        }

        public List<Transaction> GetUserTransactions(int UserId)
        {
            var user = _context.Users
                       .Include(u => u.Transactions) // eager load Transactions
                       .FirstOrDefault(u => u.Id == 1);

            List<TransactionDB> transactionDBs = user.Transactions.ToList();

            var transactions = new List<Transaction>();
            foreach (var transactionDB in transactionDBs)
            {
                var transaction = new Transaction(
                    transactionDB.Value,
                    transactionDB.Category,
                    transactionDB.IsIncome,
                    transactionDB.Date,
                    transactionDB.Currency
                );
                transactions.Add(transaction);
            }

            Console.WriteLine(transactions);

            return transactions;
        }
    }
}
