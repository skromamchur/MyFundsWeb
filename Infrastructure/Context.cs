using Infrastructure.Enteties;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class Context : DbContext
    {
        private readonly string _connectionString;

        public Context(string connectionString) {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }

        public DbSet<UserDB> Users { get; set; }
    }
}
