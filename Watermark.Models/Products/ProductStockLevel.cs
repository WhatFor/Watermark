using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Watermark.Models.Products
{
    public class ProductStockLevel
    {
        [Key]
        public int Id { get; set; }

        public int StockLevel { get; set; } = 0;

        public int LowStockThreshold { get; set; } = 0;

        public int OutOfStockThreshold { get; set; } = 0;

        public bool LowStockNotification { get; set; } = false;

        public int NotifyAtStockLevel { get; set; } = 0;

        public int MaxCountInCart { get; set; } = 0;

        [NotMapped]
        public bool IsLowStock => StockLevel <= LowStockThreshold;

        [NotMapped]
        public bool IsOutOfStock => StockLevel <= OutOfStockThreshold;
    }
}