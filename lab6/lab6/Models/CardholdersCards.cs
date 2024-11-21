using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class CardholdersCards
    {
        [Key]
        public string CardNumber { get; set; } 

        public int CardholderId { get; set; }
        public int CardTypeCode { get; set; }
        public int CurrencyCode { get; set; }

        public Cardholder Cardholder { get; set; }
        public RefCardType CardType { get; set; }
        public RefCurrencyCode Currency { get; set; }
    }
}
