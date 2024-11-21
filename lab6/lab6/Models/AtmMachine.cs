using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class AtmMachine
    {
        [Key]
        public int AtmId { get; set; }

        [Required]
        public string Location { get; set; } = string.Empty;

        public ICollection<FinancialTransaction> Transactions { get; set; } = new List<FinancialTransaction>();
    }

}
