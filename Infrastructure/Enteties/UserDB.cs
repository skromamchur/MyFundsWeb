namespace Infrastructure.Enteties
{
    public class UserDB
    {
        public UserDB(string login, string password)
        {
            this.Login = login;
            this.Password = password;
            this.Transactions = new List<TransactionDB>();
        }

        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public List<TransactionDB> Transactions { get; set; }

        public List<GoalDB> Goals {get; set;}
    }
}
