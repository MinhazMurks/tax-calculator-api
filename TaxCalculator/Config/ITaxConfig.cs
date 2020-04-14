﻿namespace TaxCalculator.Config
{
    /// <summary>
    /// Configuration that holds processing information pertaining to the tax calculation.
    /// </summary>
    public interface ITaxConfig
    {
        /// <summary>
        /// The string pattern the zip code must match in order to be a valid zip code.
        /// </summary>
        public string ZipCodePattern { get; }
        
        /// <summary>
        /// The display description of the zip code pattern.
        /// </summary>
        public string ZipCodePatternDescription { get; }
    }
}