using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class RefCurrencyCode
    {
        [Key]
        public int CurrencyCode { get; set; }

        public string Description { get; set; }

        public ICollection<CardholdersCards> Cards { get; set; }
        public ICollection<FinancialTransaction> Transactions { get; set; }
    }
}
