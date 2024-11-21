using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class Merchant
    {
        [Key]
        public int MerchantId { get; set; }

        public string CountryCode { get; set; }
        public int MerchantCategoryCode { get; set; }

        public ICollection<FinancialTransaction> Transactions { get; set; }
        public ICollection<MerchantsBanks> MerchantsBanks { get; set; }
    }
}
