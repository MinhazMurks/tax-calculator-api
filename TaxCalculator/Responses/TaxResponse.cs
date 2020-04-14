﻿ using System;

  namespace TaxCalculator.Responses
{
    /// <summary>
    /// A response that is sent when price with tax is calculated successfully.
    /// </summary>
    public class TaxResponse
    {
        /// <summary>
        /// The original price of the item.
        /// </summary>
        public float OriginalPrice { get; }
        
        /// <summary>
        /// The price of the item with tax factored in.
        /// </summary>
        public float FullPrice { get; }
        
        /// <summary>
        /// The tax rate of the item.
        /// </summary>
        public float TaxRate { get; }

        /// <summary>
        /// Constructor to create a new <see cref="TaxResponse"/>.
        /// </summary>
        /// <param name="originalPrice">The original price of the item.</param>
        /// <param name="fullPrice">The price of the item with tax factored in.</param>
        /// <param name="taxRate">The tax rate of the item.</param>
        public TaxResponse(float originalPrice, float fullPrice, float taxRate)
        {
            this.OriginalPrice = originalPrice;
            this.FullPrice = fullPrice;
            this.TaxRate = taxRate;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return OriginalPrice.Equals(((TaxResponse) obj).OriginalPrice) && FullPrice.Equals(((TaxResponse) obj).FullPrice) && TaxRate.Equals(((TaxResponse) obj).TaxRate);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(OriginalPrice, FullPrice, TaxRate);
        }
    }
}