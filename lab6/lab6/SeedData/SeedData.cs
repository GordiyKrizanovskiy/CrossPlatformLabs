using Lab6.Data;
using Lab6.Models;

namespace Lab6.SeedData
{
    public static class SeedData
    {
        public static void Initialize(FinancialDbContext context)
        {
            if (!context.AtmMachines.Any())
            {
                context.AtmMachines.AddRange(
                    new AtmMachine { Location = "Central Park" },
                    new AtmMachine { Location = "Main Street" }
                );
                context.SaveChanges();
            }

            if (!context.Banks.Any())
            {
                context.Banks.AddRange(
                    new Bank { Name = "Bank A" },
                    new Bank { Name = "Bank B" }
                );
                context.SaveChanges();
            }

            if (!context.Cardholders.Any())
            {
                context.Cardholders.AddRange(
                    new Cardholder { AccountNr = "123456789", CountryCode = "US" },
                    new Cardholder { AccountNr = "987654321", CountryCode = "UK" }
                );
                context.SaveChanges();
            }

            if (!context.RefCardTypes.Any())
            {
                context.RefCardTypes.AddRange(
                    new RefCardType { Description = "Credit" },
                    new RefCardType { Description = "Debit" }
                );
                context.SaveChanges();
            }

            if (!context.RefCurrencyCodes.Any())
            {
                context.RefCurrencyCodes.AddRange(
                    new RefCurrencyCode { Description = "USD" },
                    new RefCurrencyCode { Description = "EUR" }
                );
                context.SaveChanges();
            }

            if (!context.CardholdersCards.Any())
            {
                context.CardholdersCards.AddRange(
                    new CardholdersCards { CardNumber = "CARD1", CardholderId = 1, CardTypeCode = 1, CurrencyCode = 1 },
                    new CardholdersCards { CardNumber = "CARD2", CardholderId = 2, CardTypeCode = 2, CurrencyCode = 2 }
                );
                context.SaveChanges();
            }

            if (!context.Merchants.Any())
            {
                context.Merchants.AddRange(
                    new Merchant { CountryCode = "US", MerchantCategoryCode = 1 },
                    new Merchant { CountryCode = "UK", MerchantCategoryCode = 2 }
                );
                context.SaveChanges();
            }

            if (!context.FinancialTransactions.Any())
            {
                context.FinancialTransactions.AddRange(
                    new FinancialTransaction
                    {
                        CardNumber = "CARD1",
                        CurrencyCode = 1,
                        AtmId = 1,
                        MerchantId = 1, 
                        TransactionTypeCode = 1
                    },
                    new FinancialTransaction
                    {
                        CardNumber = "CARD2",
                        CurrencyCode = 2,
                        AtmId = 2,
                        MerchantId = 2,
                        TransactionTypeCode = 2
                    }
                );
                context.SaveChanges();
            }

        }
    }
}
