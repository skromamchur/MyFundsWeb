using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Transaction
    {
        public Transaction(decimal value, string category, bool isIncome, DateTime date, string currency)
        {
            this.Value = value;
            this.Category = category;
            this.IsIncome = isIncome;
            this.Date = date;
            this.Currency = currency;
        }

        public Transaction(decimal value, string category, bool isIncome, DateTime date, string currency, int userId)
        {
            this.Value = value;
            this.Category = category;
            this.IsIncome = isIncome;
            this.Date = date;
            this.Currency = currency;
            this.UserId = userId;
        }

        public decimal Value { get; set; }

        public string Category { get; set; }

        public bool IsIncome { get; set; }

        public DateTime Date { get; set; }

        public string Currency { get; set; }

        public int UserId { get; set; }
    }
}
