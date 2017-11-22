using System.ComponentModel.DataAnnotations;

namespace Watermark.Models
{
    public class TaxRate
    {
        [Key]
        public int Id { get; set; }

        public int WholeNumberTaxRate { get; set; }
    }
}