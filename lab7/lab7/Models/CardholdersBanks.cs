using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab7.Models
{
    public class CardholdersBanks
    {
        [Key]
        public int CardholderBankId { get; set; } // PK
        public int CardholderId { get; set; } // FK
        public int BankId { get; set; } // FK

        // Навігаційні властивості
        public Cardholder Cardholder { get; set; } = null!;
        public Bank Bank { get; set; } = null!;
    }
}
