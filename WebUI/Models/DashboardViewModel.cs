using Domain.Models;

namespace WebUI.Models
{
    public class DashboardViewModel
    {
        public List<TransactionCategory> incomeTransactions { get; set; } = new List<TransactionCategory>();
        public List<TransactionCategory> expendTransactions { get; set; } = new List<TransactionCategory>();
    }
}
