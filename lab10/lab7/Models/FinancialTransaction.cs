using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab7.Models
{
    public class FinancialTransaction
    {
        [Key]
        public int TransactionId { get; set; } // PK
        public string? ATMId { get; set; } // FK
        public string CardNumber { get; set; } = string.Empty; // FK
        public string? MerchantId { get; set; } // FK
        public string CurrencyCode { get; set; } = string.Empty; // FK

        // Навігаційні властивості
        public ATMMachine? ATM { get; set; } // Зв'язок із ATM
        public CardholdersCards Card { get; set; } = null!;
        public Merchant? Merchant { get; set; } // Зв'язок із Merchant
        public RefCurrencyCodes Currency { get; set; } = null!;
    }
}
