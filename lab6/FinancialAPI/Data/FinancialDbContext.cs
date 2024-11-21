using Microsoft.EntityFrameworkCore;
using FinancialAPI.Models;

namespace FinancialAPI.Data
{
    public class FinancialDbContext : DbContext
    {
        public FinancialDbContext(DbContextOptions<FinancialDbContext> options) : base(options) { }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
