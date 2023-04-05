namespace Domain.Models
{
    public class Transaction
    {
        public decimal Value { get; set; }

        public string Category { get; set; } = string.Empty;

        public bool IsIncome { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;

        public string Currency { get; set; } = "usd";

        public int UserId { get; set; }
    }
}
