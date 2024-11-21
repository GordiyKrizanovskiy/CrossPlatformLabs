using Microsoft.EntityFrameworkCore;
using Lab6.Models;

namespace Lab6.Data
{
    public class FinancialDbContext : DbContext
    {
        public FinancialDbContext(DbContextOptions<FinancialDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cardholder> Cardholders { get; set; }
        public DbSet<CardholdersCards> CardholdersCards { get; set; }
        public DbSet<CardholdersBanks> CardholdersBanks { get; set; }
        public DbSet<FinancialTransaction> FinancialTransactions { get; set; }
        public DbSet<RefCardType> RefCardTypes { get; set; }
        public DbSet<RefCurrencyCode> RefCurrencyCodes { get; set; }
        public DbSet<AtmMachine> AtmMachines { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<MerchantsBanks> MerchantsBanks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardholdersCards>()
                .HasKey(cc => cc.CardNumber);

            modelBuilder.Entity<CardholdersCards>()
                .HasOne(cc => cc.Cardholder)
                .WithMany(c => c.Cards)
                .HasForeignKey(cc => cc.CardholderId);

            modelBuilder.Entity<CardholdersCards>()
                .HasOne(cc => cc.CardType)
                .WithMany(ct => ct.Cards)
                .HasForeignKey(cc => cc.CardTypeCode);

            modelBuilder.Entity<CardholdersCards>()
                .HasOne(cc => cc.Currency)
                .WithMany(rc => rc.Cards)
                .HasForeignKey(cc => cc.CurrencyCode);

            modelBuilder.Entity<CardholdersBanks>()
                .HasKey(cb => cb.CardholderBankId);

            modelBuilder.Entity<CardholdersBanks>()
                .HasOne(cb => cb.Cardholder)
                .WithMany(c => c.Banks)
                .HasForeignKey(cb => cb.CardholderId);

            modelBuilder.Entity<CardholdersBanks>()
                .HasOne(cb => cb.Bank)
                .WithMany(b => b.CardholdersBanks)
                .HasForeignKey(cb => cb.BankId);

            modelBuilder.Entity<FinancialTransaction>()
                .HasKey(ft => ft.TransactionId);

            modelBuilder.Entity<FinancialTransaction>()
                .HasOne(ft => ft.Card)
                .WithMany()
                .HasForeignKey(ft => ft.CardNumber)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FinancialTransaction>()
                .HasOne(ft => ft.Currency)
                .WithMany(rc => rc.Transactions)
                .HasForeignKey(ft => ft.CurrencyCode)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FinancialTransaction>()
                .HasOne(ft => ft.Atm)
                .WithMany(a => a.Transactions)
                .HasForeignKey(ft => ft.AtmId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FinancialTransaction>()
                .HasOne(ft => ft.Merchant)
                .WithMany(m => m.Transactions)
                .HasForeignKey(ft => ft.MerchantId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MerchantsBanks>()
                .HasKey(mb => new { mb.MerchantId, mb.BankId });

            modelBuilder.Entity<MerchantsBanks>()
                .HasOne(mb => mb.Merchant)
                .WithMany(m => m.MerchantsBanks)
                .HasForeignKey(mb => mb.MerchantId);

            modelBuilder.Entity<MerchantsBanks>()
                .HasOne(mb => mb.Bank)
                .WithMany(b => b.MerchantsBanks)
                .HasForeignKey(mb => mb.BankId);
        }
    }
}
