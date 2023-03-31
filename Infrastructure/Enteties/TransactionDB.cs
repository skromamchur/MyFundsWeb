namespace Infrastructure.Enteties
{
    public class TransactionDB
    {
        public int Id { get; set; }

        public decimal Value { get; set; }

        public string Category { get; set; }

        public bool IsIncome { get; set; }

        public DateTime Date { get; set; }

        public string Currency { get; set; }
        
        public UserDB User { get; set; }
    }
}
