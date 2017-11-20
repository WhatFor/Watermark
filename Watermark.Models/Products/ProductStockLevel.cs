namespace Watermark.Models.Products
{
    public class ProductStockLevel
    {
        public uint StockLevel { get; set; } = 0;

        public uint LowStockThreshold { get; set; } = 0;

        public uint OutOfStockThreshold { get; set; } = 0;

        public bool LowStockNotification { get; set; } = false;

        public uint NotifyAtStockLevel { get; set; } = 0;

        public uint MaxCountInCart { get; set; } = 0;

        public bool IsLowStock => StockLevel <= LowStockThreshold;

        public bool IsOutOfStock => StockLevel <= OutOfStockThreshold;
    }
}