namespace Watermark.Models.Products
{
    public class PhysicalProduct : BaseProduct
    {
        public override ProductType ProductType => ProductType.PhysicalProduct;

        /*      Requirements      */
        // - two types of products? physical/digital
        // - Normal price - sys wide currency,
        // - Special price,
        // - Multi-buy pricing,
        // - global settings overrides, e.g. out of stock threshold, low stock threshold, max quantity in shopping cart, notifiy when stock below X,
        // - Taxable - system wide default tax rate,
        // - display name,
        // - media - main image? additional images?,
        // - description,
        // - active from, active to,
        // - is active,
        // - sites included on,
        // - SEO,
        // - categories,
        // - related products, upsells, crosssells,
        // - product code - SKU,
        // - Reviews,
        // - description sections (custom or templates) - i.e. product attributes? e.g. Dimensions
        // - Template ID? -> Templates
        // - Multiple variants, i.e. add 'Color' variant. Add 'Red', 'Blue' and 'Green' colour variants.
        // - Stock levels? -- should this be handled here?
        // - Delivery time type, i.e. is this 1-2 day shipping? UK or worldwide? define delivery types as templates. Select from templates or set custom.
    }
}