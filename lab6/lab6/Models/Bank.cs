using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class Bank
    {
        [Key]
        public int BankId { get; set; } 

        public string Name { get; set; }

        public ICollection<CardholdersBanks> CardholdersBanks { get; set; }
        public ICollection<MerchantsBanks> MerchantsBanks { get; set; }
    }
}
