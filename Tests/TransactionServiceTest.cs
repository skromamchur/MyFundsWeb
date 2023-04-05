using Domain.Services.Interfaces;
using Newtonsoft.Json.Linq;

namespace Tests
{
    public class TransactionServiceTest
    {
        private Mock<ITransactionRepository> _transactionRepositoryMock;
        private ITransactionService _transactionService;

        [SetUp]
        public void Setup()
        {
            _transactionRepositoryMock = new Mock<ITransactionRepository>();
            _transactionService = new TransactionService(_transactionRepositoryMock.Object);
        }

        [Test]
        public void TransactionService_AddTransaction_OneTime()
        {
            Transaction transaction = new Transaction(){ 
                Value = 100,
                Currency = "usd",
                IsIncome = false,
                Category = "Food",
                Date = DateTime.UtcNow,
            };

            _transactionService.AddTransaction(transaction);

            _transactionRepositoryMock.Verify(x => x.addTransaction(transaction), Times.Once);
        }

        [Test]
        public void TransactionService_GetUserTransations()
        {
            int userId = 1;

            List<Transaction> transactions = new List<Transaction>()
                {
                    new Transaction { UserId = 1, IsIncome = true, Value = 100 },
                    new Transaction { UserId = 2, IsIncome = false, Value = 50 },
                    new Transaction { UserId = 3, IsIncome = false, Value = 25 },
                    new Transaction { UserId = 1, IsIncome = true, Value = 50 }
                };

            _transactionRepositoryMock.Setup(x => x.GetAllTransactions()).Returns(transactions);

            List<Transaction> result = _transactionService.GetUserTransactions(userId);

            CollectionAssert.AreEqual(transactions.Where(t => t.UserId == userId).ToList(), result);
        }

        [Test]
        public void GetUserTransactionsDividedIntoCategories_ShouldReturnCorrectCategories()
        {
            int userId = 1;
            bool isIncome = true;

            var transactions = new List<Transaction>()
            {
                new Transaction { UserId = userId, Category = "Salary", Value = 1000, IsIncome = isIncome },
                new Transaction { UserId = userId, Category = "Salary", Value = 500, IsIncome = isIncome },
                new Transaction { UserId = 2, Category = "Salary", Value = 1000, IsIncome = isIncome },
                new Transaction { UserId = userId, Category = "Partnership", Value = 2000, IsIncome = isIncome },
                new Transaction { UserId = userId, Category = "Entertainment", Value = 1000, IsIncome = !isIncome },
            };

            _transactionRepositoryMock.Setup(r => r.GetAllTransactions()).Returns(transactions);

            var expectedCategories = new List<TransactionCategory>()
            {
                new TransactionCategory { Name = "Salary", Value = 1500 },
                new TransactionCategory { Name = "Partnership", Value = 2000 },
            };

            var result = _transactionService.GetUserTransactionsDividedIntoCategories(userId, isIncome);

            CollectionAssert.AreEqual(expectedCategories, result);
        }
    }
}
