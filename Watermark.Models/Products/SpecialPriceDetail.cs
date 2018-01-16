using System;
using System.ComponentModel.DataAnnotations;

namespace Watermark.Models.Products
{
    public class SpecialPriceDetail : PriceDetail
    {
        /// <summary>
        /// The reduced, special price.
        /// </summary>
        [Display(Name = "Special Price", Description = "A product's special, reduced price, as shown when a product is discounted.")]
        public override decimal Cost { get; set; }

        /// <summary>
        /// Whether the special price should become active on a given date. If null, will be active instantly.
        /// </summary>
        [Display(Name = "Start", Description = "The date at which the promotional price will begin. Leaving this option blank will cause the promotion to begin immediately.")]
        public DateTimeOffset? SpecialPriceBeginningDate { get; set; }

        /// <summary>
        /// An optional end date for the special price end. Leave null to run the special price indefinetely.
        /// </summary>
        [Display(Name = "End", Description = "The date at which the promotional price will end. Leaving this option blank will cause the promotion to run indefinitely.")]
        public DateTimeOffset? SpecialPriceEndDate { get; set; }

        /// <summary>
        /// Whether to display a countdown to the end of the special price on the product page.
        /// </summary>
        public bool DisplayEndDateAlert { get; set; }

        /// <summary>
        /// Whether to override the special price active dates and enable/disable the special price.
        /// </summary>
        public bool? SpecialPriceActiveOverride { get; set; }

        /// <summary>
        /// Whether to display the base price as the original, before-discount price on the product page.
        /// </summary>
        public bool DisplayBasePrice { get; set; }

        /// <summary>
        /// Check if the product special price is currently set to active.
        /// </summary>
        public bool IsSpecialActive => IsSpecial();

        private bool IsSpecial()
        {
            // If the special has an override, return that.
            if (SpecialPriceActiveOverride != null)
            {
                return SpecialPriceActiveOverride.Value;
            }

            // If the special price has no beginning price, but has an end date
            if (SpecialPriceBeginningDate == null && SpecialPriceEndDate.HasValue && DateTime.Now < SpecialPriceEndDate)
            {
                return true;
            }

            // If the special price has a beginning date but no end date
            if (SpecialPriceEndDate == null && SpecialPriceBeginningDate.HasValue && DateTime.Now > SpecialPriceBeginningDate)
            
            if (DateTime.Now > SpecialPriceBeginningDate && DateTime.Now < SpecialPriceEndDate)
            {
                return true;
            }

            // If all of the above fail, the product is not on special
            return false;
        }
    }
}
