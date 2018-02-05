using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Watermark.Models.Products.Contracts;

namespace Watermark.Models.Products
{
    public class Product : IProduct
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Product Type", Description = "The type of product - either physical or digital.")]
        public ProductType ProductType { get; set;  }

        public ProductName ProductName { get; set; } = new ProductName();

        public ProductSKU ProductSKU { get; set; } = new ProductSKU();

        [Required]
        [Display(Name = "Active Product", Description = "Whether the product is active or not. Inactive products will not be displayed.")]
        public bool Active { get; set; }

        public ProductPricing PriceInformation { get; set; } = new ProductPricing();

        public List<ProductMedia> ProductMedia { get; set; } = new List<ProductMedia>();

        public List<ProductDescription> Descriptions { get; set; } = new List<ProductDescription>();

        public bool TemporaryWithLifetime { get; set; }

        public Lifetime Lifetime { get; set; }

        public ProductTemplate Template { get; set; }

        public List<Site> Sites { get; set; } = new List<Site>();

        public ProductSearchEngineOptimisation SearchEngineOptimisationOptions { get; set; } = new ProductSearchEngineOptimisation();

        public List<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

        public ProductStockLevel StockLevels { get; set; } = new ProductStockLevel();

        public List<ProductAttribute> ProductAttributes { get; set; } = new List<ProductAttribute>();

        public List<Product> RelatedProducts { get; set; } = new List<Product>();

        public List<Product> UpsellProducts { get; set; } = new List<Product>();

        public List<Product> CrossSellProducts { get; set; } = new List<Product>();

        public List<ProductReview> Reviews { get; set; } = new List<ProductReview>();

        public List<ProductConfiguration> Configurations { get; set; } = new List<ProductConfiguration>();

        public List<ProductDeliveryOption> DeliveryOptions { get; set; } = new List<ProductDeliveryOption>();

        public List<ProductSettingOverride> SettingOverrides { get; set; } = new List<ProductSettingOverride>();

        [NotMapped]
        public bool HasCategories => ProductCategories.Any();

        [NotMapped]
        public bool HasConfigurations => Configurations.Any();

        [NotMapped]
        public bool HasCrossSellProducts => CrossSellProducts.Any();

        [NotMapped]
        public bool HasUpsellProducts => UpsellProducts.Any();

        [NotMapped]
        public bool HasRelatedProducts => RelatedProducts.Any();

        [NotMapped]
        public bool HasDeliveryOptions => DeliveryOptions.Any();

        [NotMapped]
        public bool HasDescription => Descriptions.Any();

        [NotMapped]
        public bool HasLifetime => Lifetime != null;

        [NotMapped]
        public bool HasMedia => ProductMedia.Any();

        [NotMapped]
        public bool HasOverrides => SettingOverrides.Any();

        [NotMapped]
        public bool HasPriceInformation => PriceInformation != null;

        [NotMapped]
        public bool HasProductAttributes => ProductAttributes.Any();

        [NotMapped]
        public bool HasReviews => Reviews.Any();

        [NotMapped]
        public bool HasSKU => ProductSKU != null;

        [NotMapped]
        public bool HasTemplate => Template != null;

        public List<ProductMedia> GetMediaByType(MediaType type)
        {
            return ProductMedia.Where(m => m.MediaType == type).ToList();
        }

        public ProductMedia GetPrimaryMedia()
        {
            return ProductMedia.SingleOrDefault(m => m.PrimaryMedia == true);
        }

        public bool IsActive()
        {
            return (TemporaryWithLifetime && Lifetime.HasBegun) || Active;
        }
    }
}