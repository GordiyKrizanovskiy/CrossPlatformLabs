using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class Cardholder
    {
        [Key]
        public int CardholderId { get; set; } 

        public string AccountNr { get; set; }
        public string CountryCode { get; set; }

        public ICollection<CardholdersCards> Cards { get; set; }
        public ICollection<CardholdersBanks> Banks { get; set; }
    }
}
