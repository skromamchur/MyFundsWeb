using Domain.Models;

namespace WebUI.Models
{
    public class GoalViewModel
    {
        public decimal FinalValue { get; set; }

        public string Name { get; set; } = String.Empty;

        public string Currency { get; set; } = String.Empty;

        public List<string> Currencies { get; } = new List<string> { "usd" };

        public List<Goal> Goals { get; set; } = new List<Goal>();

        public int GoalId { get; set; }

        public decimal AddMoney { get; set; }

        public UpdateGoalForm updateGoalForm { get; set; } = new UpdateGoalForm{ };
    }
}
