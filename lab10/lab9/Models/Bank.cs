namespace lab9.Models
{
    public class Bank
    {
        [Key]
        public int BankId { get; set; } // PK
        public string BankName { get; set; } = string.Empty;
    }
}
