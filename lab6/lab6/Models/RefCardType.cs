using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class RefCardType
    {
        [Key]
        public int CardTypeCode { get; set; }

        public string Description { get; set; }

        public ICollection<CardholdersCards> Cards { get; set; }
    }
}
