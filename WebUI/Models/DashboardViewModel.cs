using Domain.Models;

namespace WebUI.Models
{
    public class DashboardViewModel
    {
        public List<TransactionCategory> IncomeTransactions { get; set; } = new List<TransactionCategory>();
        public List<TransactionCategory> ExpendTransactions { get; set; } = new List<TransactionCategory>();
    }
}
