using System.Collections.Generic;

namespace Watermark.Models.Products.Contracts
{
    public interface IProduct
    {
        int Id { get; }

        ProductType ProductType { get; }

        ProductName ProductName { get; set; }

        ProductSKU ProductSKU { get; set; }

        bool Active { get; set; }

        ProductPricing PriceInformation { get; set; }

        List<ProductMedia> ProductMedia { get; set; }

        List<ProductDescription> Descriptions { get; set; }

        bool TemporaryWithLifetime { get; set; }

        Lifetime Lifetime { get; set; }

        ProductTemplate Template { get; set; }

        List<Site> Sites { get; set; }

        ProductSearchEngineOptimisation SearchEngineOptimisationOptions { get; set; }

        List<ProductCategory> ProductCategories { get; set; }

        ProductStockLevel StockLevels { get; set; }

        List<ProductAttribute> ProductAttributes { get; set; }

        List<IProduct> RelatedProducts { get; set; }

        List<IProduct> UpsellProducts { get; set; }

        List<IProduct> CrossSellProducts { get; set; }

        List<ProductReview> Reviews { get; set; }
     
        List<ProductConfiguration> Configurations { get; set; }

        List<ProductDeliveryOption> DeliveryOptions { get; set; }

        List<ProductSettingOverride> SettingOverrides { get; set; }

        bool HasDeliveryOptions { get; }

        bool HasConfigurations { get; }

        bool HasPriceInformation { get; }

        bool HasCrossSellProducts { get; }

        bool HasRelatedProducts { get; }

        bool HasUpsellProducts { get; }

        bool HasProductAttributes { get; }

        bool HasDescription { get; }

        bool HasCategories { get; }

        bool HasTemplate { get; }

        bool HasLifetime { get; }

        bool HasOverrides { get; }

        bool HasReviews { get; }

        bool HasMedia { get; }

        bool HasSKU { get; }

        List<ProductMedia> GetMediaByType(ProductMediaType type);

        ProductMedia GetPrimaryMedia();

        bool IsActive();
    }
}