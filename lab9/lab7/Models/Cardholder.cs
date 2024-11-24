using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace lab7.Models
{
    public class Cardholder
    {
        [Key]
        public int CardholderId { get; set; } // PK
        public string AccountNumber { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;

        // Navigation Properties
        public List<CardholdersCards> Cards { get; set; } = new();
        public List<CardholdersBanks> Banks { get; set; } = new();
    }
}

