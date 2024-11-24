using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab7.Models
{
    public class MerchantsBanks
    {
        public int MerchantId { get; set; } // FK
        public int BankId { get; set; } // FK

        // Навігаційні властивості
        public Merchant Merchant { get; set; } = null!;
        public Bank Bank { get; set; } = null!;
    }
}
