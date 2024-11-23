using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab7.Models
{
    public class RefCurrencyCodes
    {
        [Key]
        public string CurrencyCode { get; set; } = string.Empty; // PK
        public string CurrencyName { get; set; } = string.Empty;

        // Навігаційні властивості
        public List<CardholdersCards> Cards { get; set; } = new();
        public List<FinancialTransaction> Transactions { get; set; } = new(); // Зв'язок із FinancialTransactions
    }
}
