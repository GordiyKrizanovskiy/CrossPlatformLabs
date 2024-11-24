using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab7.Models
{
    public class RefCardTypes
    {
        [Key]
        public string CardTypeCode { get; set; } = string.Empty; // PK
        public string Description { get; set; } = string.Empty;

        // Навігаційна властивість
        public List<CardholdersCards> Cards { get; set; } = new();
    }
}
