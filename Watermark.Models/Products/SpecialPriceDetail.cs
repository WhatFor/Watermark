using System;
using System.ComponentModel.DataAnnotations;

namespace Watermark.Models.Products
{
    public class SpecialPriceDetail : PriceDetail
    {
        /// <summary>
        /// The reduced, special price.
        /// </summary>
        [Display(Name = "Special Price", Description = "A product's reduced price, as shown when a product is discounted.")]
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
        [Display(Name = "Show End Alert", Description = "Wether or not to display an alert (including a timer) for when the promotional price will end.")]

        public bool DisplayEndDateAlert { get; set; }

        /// <summary>
        /// Whether to display the base price as the original, before-discount price on the product page.
        /// </summary>
        [Display(Name = "Show Base Price", Description = "Wether the product listing should display the base price as well as the promotional price.")]

        public bool DisplayBasePrice { get; set; }

        /// <summary>
        /// Check if the product special price is currently set to active.
        /// </summary>
        public bool IsSpecialActive => IsSpecial();

        private bool IsSpecial()
        {
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

            // If the above fails, the product is not on special
            return false;
        }
    }
}
