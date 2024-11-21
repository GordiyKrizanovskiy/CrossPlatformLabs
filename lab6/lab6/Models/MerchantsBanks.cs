using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class MerchantsBanks
    {
        [Key]
        public int MerchantBankId { get; set; } 

        public int MerchantId { get; set; }
        public int BankId { get; set; }

        public Merchant Merchant { get; set; }
        public Bank Bank { get; set; }
    }
}
