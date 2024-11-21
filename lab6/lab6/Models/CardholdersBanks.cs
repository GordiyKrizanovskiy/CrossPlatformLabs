using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class CardholdersBanks
    {
        [Key]
        public int CardholderBankId { get; set; }

        public int CardholderId { get; set; }
        public int BankId { get; set; }

        public Cardholder Cardholder { get; set; }
        public Bank Bank { get; set; }
    }
}
