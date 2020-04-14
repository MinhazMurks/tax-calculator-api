﻿using TaxCalculator.Config;

 namespace TaxCalculator.Utilities
{
    /// <summary>
    /// Service to validate endpoint inputs.
    /// </summary>
    public interface ITaxInputUtility
    {
        /// <summary>
        /// Validates the price input is a valid floating point value.
        /// </summary>
        /// <param name="price">The price of the item.</param>
        /// <returns>A <see <code>float</code> representation of the <code>price</code>, if it is valid.</returns>
        /// <exception cref="System.ArgumentException">Thrown when the <code>price</code> is not a valid floating point
        /// value.</exception>
        public float ValidatePrice(string price);
        
        /// <summary>
        /// Validates the zip code input matches the zip code pattern specified in <see cref="TaxConfig"/>.
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns>A <code>string</code> representation of the <code>zipCode</code>, if it is valid.</returns>
        /// <exception cref="System.ArgumentException">Thrown when the <code>price</code> if it does not match
        /// the zip code pattern</exception>
        public string ValidateZipCode(string zipCode);
    }
}