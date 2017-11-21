using System.Collections.Generic;
using System.Linq;
using Watermark.Models.Products.Contracts;

namespace Watermark.Models.Products
{
    public class Product : IProduct
    {
        public int Id { get; }

        public virtual ProductType ProductType { get; }

        public ProductName ProductName { get; set; } = new ProductName();

        public ProductSKU ProductSKU { get; set; } = new ProductSKU();

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

        public bool HasCategories => ProductCategories.Any();

        public bool HasConfigurations => Configurations.Any();

        public bool HasCrossSellProducts => CrossSellProducts.Any();

        public bool HasUpsellProducts => UpsellProducts.Any();

        public bool HasRelatedProducts => RelatedProducts.Any();

        public bool HasDeliveryOptions => DeliveryOptions.Any();

        public bool HasDescription => Descriptions.Any();

        public bool HasLifetime => Lifetime != null;

        public bool HasMedia => ProductMedia.Any();

        public bool HasOverrides => SettingOverrides.Any();

        public bool HasPriceInformation => PriceInformation != null;

        public bool HasProductAttributes => ProductAttributes.Any();

        public bool HasReviews => Reviews.Any();

        public bool HasSKU => ProductSKU != null;

        public bool HasTemplate => Template != null;

        public List<ProductMedia> GetMediaByType(ProductMediaType type)
        {
            return ProductMedia.Where(m => m.MediaType == type).ToList();
        }

        public ProductMedia GetPrimaryMedia()
        {
            return ProductMedia.SingleOrDefault(m => m.PrimaryMedia);
        }

        public bool IsActive()
        {
            return (TemporaryWithLifetime && Lifetime.HasBegun) || Active;
        }
    }
}