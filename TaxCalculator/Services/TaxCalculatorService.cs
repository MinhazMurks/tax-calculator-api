using TaxCalculator.Models;
using TaxCalculator.Responses;

namespace TaxCalculator.Services
{
    /// <summary>
    /// Implementation for <see cref="ITaxCalculatorService"/>.
    /// </summary>
    public class TaxCalculatorService : ITaxCalculatorService
    {
        public TaxResponse CalculateTax(float price, RegionTax regionTax)
        {
            float fullPrice = (price * regionTax.EstimatedCombinedRate) + price;
            return new TaxResponse(price, fullPrice, regionTax.EstimatedCombinedRate);
        }
    }
}