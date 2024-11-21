using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class FinancialTransaction
    {
        [Key]
        public int TransactionId { get; set; }

        public DateTime TransactionDate { get; set; }

        [Required]
        public string CardNumber { get; set; } = string.Empty;

        public CardholdersCards Card { get; set; } = null!;

        [Required]
        public int CurrencyCode { get; set; }

        public RefCurrencyCode Currency { get; set; } = null!;

        public int? AtmId { get; set; }
        public AtmMachine? Atm { get; set; }

        public int? MerchantId { get; set; }
        public Merchant? Merchant { get; set; }

        [Required]
        public int TransactionTypeCode { get; set; }
    }

}
