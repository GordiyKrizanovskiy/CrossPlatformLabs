using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab7.Models
{
    public class CardholdersCards
    {
        [Key]
        public string CardNumber { get; set; } = string.Empty; // PK
        public int CardholderId { get; set; } // FK
        public string CardTypeCode { get; set; } = string.Empty; // FK
        public string CurrencyCode { get; set; } = string.Empty; // FK

        // Навігаційні властивості
        public Cardholder Cardholder { get; set; } = null!;
        public RefCardTypes CardType { get; set; } = null!;
        public RefCurrencyCodes Currency { get; set; } = null!;
    }
}
