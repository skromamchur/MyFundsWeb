using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Goal
    {
        public int Id { get; set; }
        public decimal CurrentValue { get; set; }
        public decimal FinalValue { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string Currency { get; set; } = "usd";
        public int UserId { get; set; }
    }
}
