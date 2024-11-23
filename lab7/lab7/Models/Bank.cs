using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab7.Models
{
    public class Bank
    {
        [Key]
        public int BankId { get; set; } // PK
        public string BankName { get; set; } = string.Empty;

        // Навігаційні властивості
        public List<CardholdersBanks> CardholdersBanks { get; set; } = new();
        public List<MerchantsBanks> MerchantsBanks { get; set; } = new(); // Зв'язок із MerchantsBanks
    }
}
