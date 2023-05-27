namespace WebUI.Models
{
    public class UpdateGoalForm
    {
        public string Name { get; set; } = string.Empty;
        public decimal FinalValue { get; set; }
        public decimal CurrentValue { get; set; }
    }
}
