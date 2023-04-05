using Domain.Models;

namespace WebUI.Models
{
    public class TransactionViewModel
    {
        public decimal Value { get; set; }

        public string Category { get; set; } = String.Empty;

        public string Currency { get; set; } = String.Empty;

        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public List<string> IncomeCategories { get; } = new List<string>{ "Salary", "Business Income", "Freelance Income", "Investment Income", "Rental Income", "Side Hustles", "Gambling or Lottery Winnings", "Partnership" };
        public List<string> ExpendCategories { get; } = new List<string> { "Food", "Rent", "Utilities (electricity, gas, water, etc.)", "Entertainment", "Transportation", "Clothing", "Health care", "Education", "Gifts/Donations", "Travel", "Subscription services", "Emergency savings" };
        public List<string> Currencies { get; } = new List<string> { "usd" };
    }
}
