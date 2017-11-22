using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Watermark.Models.Products
{
    public class ProductReview
    {
        [Key]
        public int Id { get; set; }

        public int ReviewerId { get; set; }

        public int ProductId { get; set; }

        public string Title { get; set; }

        public int Rating { get; set; }

        public string Body { get; set; }

        [NotMapped]
        public bool HasBody => String.IsNullOrWhiteSpace(Body);

        [NotMapped]
        public bool HasRating => Rating != 0;
    }
}