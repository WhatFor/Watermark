using System.ComponentModel.DataAnnotations;
using Watermark.Models.Admin.Configuration;

namespace Watermark.Models
{
    public class Site
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public Configuration SiteConfiguration { get; set; }
    }
}