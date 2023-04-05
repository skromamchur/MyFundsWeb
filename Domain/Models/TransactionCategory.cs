namespace Domain.Models
{
    public class TransactionCategory
    {
        public string Name { get; set; } = string.Empty;

        public decimal Value { get; set; } = 0;

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (TransactionCategory)obj;
            return Name == other.Name && Value == other.Value;
        }

        public override int GetHashCode()
        {
            return (Name, Value).GetHashCode();
        }
    }
}
