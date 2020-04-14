using System;
using System.Text.RegularExpressions;
using TaxCalculator.Config;

namespace TaxCalculator.Utilities
{
    /// <summary>
    /// Implementation of <see cref="ITaxInputUtility"/>.
    /// </summary>
    public class TaxInputUtility : ITaxInputUtility
    {
        /// <summary>
        /// The <see cref="ITaxConfig"/> with configuration information.
        /// </summary>
        private readonly ITaxConfig _taxConfig;
        
        /// <summary>
        /// Constructor to create a new <see cref="TaxInputUtility"/>.
        /// </summary>
        /// <param name="taxConfig">The <see cref="ITaxConfig"/> with configuration information.</param>
        public TaxInputUtility(ITaxConfig taxConfig)
        {
            _taxConfig = taxConfig;
        }

        public float ValidatePrice(string price)
        {
            if (float.TryParse(price, out float priceFloat))
            {
                return priceFloat;
            }
            throw new ArgumentException($"Price [{price}] is invalid, must be a floating point number.");
        }

        public string ValidateZipCode(string zipCode)
        {
            if (zipCode != null && Regex.Match(zipCode.Trim(), _taxConfig.ZipCodePattern, RegexOptions.None).Success)
            {
                return zipCode.Trim();
            }
            throw new ArgumentException($"Zip code [{zipCode}] is invalid, must be {_taxConfig.ZipCodePatternDescription}.");
        }
    }
}