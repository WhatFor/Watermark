using System.ComponentModel.DataAnnotations;

namespace Watermark.Models
{
    public class Site
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}