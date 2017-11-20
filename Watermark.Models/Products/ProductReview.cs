using System;

namespace Watermark.Models.Products
{
    public class ProductReview
    {
        public int Id { get; set; }

        public int ReviewerId { get; set; }

        public int ProductId { get; set; }

        public string Title { get; set; }

        public int Rating { get; set; }

        public string Body { get; set; }

        public bool HasBody => String.IsNullOrWhiteSpace(Body);

        public bool HasRating => Rating != 0;
    }
}