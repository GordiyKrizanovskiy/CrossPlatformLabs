using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab7.Models
{
    public class Merchant
    {
        [Key]
        public int MerchantId { get; set; } // PK
        public string CountryCode { get; set; } = string.Empty; // FK
        public string MerchantCategoryCode { get; set; } = string.Empty; // FK

        // Навігаційні властивості
        public List<MerchantsBanks> MerchantsBanks { get; set; } = new(); // Зв'язок із MerchantsBanks
        public List<FinancialTransaction> FinancialTransactions { get; set; } = new(); // Зв'язок із FinancialTransactions
    }
}
