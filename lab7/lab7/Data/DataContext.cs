using Microsoft.EntityFrameworkCore;
using lab7.Models;

namespace lab7.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Cardholder> Cardholders { get; set; }
        public DbSet<CardholdersCards> CardholdersCards { get; set; }
        public DbSet<RefCardTypes> RefCardTypes { get; set; }
        public DbSet<RefCurrencyCodes> RefCurrencyCodes { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<CardholdersBanks> CardholdersBanks { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<MerchantsBanks> MerchantsBanks { get; set; }
        public DbSet<ATMMachine> ATMMachines { get; set; }
        public DbSet<FinancialTransaction> FinancialTransactions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MerchantsBanks>()
                .HasKey(mb => new { mb.MerchantId, mb.BankId }); // Визначення складеного ключа
        }

    }
}
