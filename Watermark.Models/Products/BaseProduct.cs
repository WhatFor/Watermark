using System.Collections.Generic;
using System.Linq;
using Watermark.Models.Products.Contracts;

namespace Watermark.Models.Products
{
    public class BaseProduct : IProduct
    {
        public int Id { get; }

        public virtual ProductType ProductType { get; }

        public ProductName ProductName { get; set; }

        public ProductSKU ProductSKU { get; set; }

        public bool Active { get; set; }

        public ProductPricing PriceInformation { get; set; }

        public List<ProductMedia> ProductMedia { get; set; }

        public List<ProductDescription> Descriptions { get; set; }

        public bool TemporaryWithLifetime { get; set; }

        public Lifetime Lifetime { get; set; }

        public ProductTemplate Template { get; set; }

        public List<Site> Sites { get; set; }

        public ProductSearchEngineOptimisation SearchEngineOptimisationOptions { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }

        public ProductStockLevel StockLevels { get; set; }

        public List<ProductAttribute> ProductAttributes { get; set; }

        public List<IProduct> RelatedProducts { get; set; }

        public List<IProduct> UpsellProducts { get; set; }

        public List<IProduct> CrossSellProducts { get; set; }

        public List<ProductReview> Reviews { get; set; }

        public List<ProductConfiguration> Configurations { get; set; }

        public List<ProductDeliveryOption> DeliveryOptions { get; set; }

        public List<ProductSettingOverride> SettingOverrides { get; set; }

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