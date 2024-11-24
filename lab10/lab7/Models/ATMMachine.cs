using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace lab7.Models
{
    public class ATMMachine
    {
        [Key]
        public int ATMId { get; set; }

        // Навігаційні властивості
        public List<FinancialTransaction> FinancialTransactions { get; set; } = new();
    }
}
