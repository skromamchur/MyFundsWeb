using Domain.Models;

namespace WebUI.Models
{
    public class TransactionViewModel
    {
        public decimal Value { get; set; }

        public string Category { get; set; } = String.Empty;

        public bool IsIncome { get; set; }

        public DateTime Date { get; set; }

        public string Currency { get; set; } = String.Empty;

        public int UserId { get; set; }

        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
