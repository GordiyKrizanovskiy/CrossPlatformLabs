namespace Lab9.Models;

public class Cardholder
{
        [Key]
        public int CardholderId { get; set; } // PK
        public string AccountNumber { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;

}
