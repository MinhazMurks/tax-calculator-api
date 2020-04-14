using TaxCalculator.Models;
using TaxCalculator.Responses;

namespace TaxCalculator.Services
{
    /// <summary>
    /// Service to calculate taxes.
    /// </summary>
    public interface ITaxCalculatorService
    {
        /// <summary>
        /// Calculates taxes according to <see cref="RegionTax"/>.
        /// </summary>
        /// <param name="price">The price of the item.</param>
        /// <param name="regionTax">The <see cref="RegionTax"/> of the area of purchase, cannot be <code>null</code>.</param>
        /// <returns>A <see cref="TaxResponse"/>.</returns>
        public TaxResponse CalculateTax(float price, RegionTax regionTax);
    }
}