using System.ComponentModel.DataAnnotations;

namespace FinancialAPI.Models
{
    public class Card
    {
        [Key]
        public required string CardNumber { get; set; }

        [Required]
        public required string CardholderName { get; set; }

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }

    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        public required string CardNumber { get; set; }
        public Card Card { get; set; } = default!;

        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
