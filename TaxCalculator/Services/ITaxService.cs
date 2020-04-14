﻿using TaxCalculator.Models;

 namespace TaxCalculator.Services
{
    /// <summary>
    /// Service to query database for <see cref="RegionTax"/>.
    /// </summary>
    public interface ITaxService
    {
        /// <summary>
        /// Queries database by zip code.
        /// </summary>
        /// <param name="zipCode">The zip code of the desired <see cref="RegionTax"/>, cannot be <code>null</code>.</param>
        /// <returns>A <see cref="RegionTax"/>.</returns>
        /// <exception cref="System.ArgumentException">Thrown when no corresponding <see cref="RegionTax"/> found.</exception>
        public RegionTax GetByZipCode(string zipCode);
    }
}