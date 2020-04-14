using System.Collections.Generic;
using System.Text.Json;
using TaxCalculator.Models;

namespace TaxCalculator.Repository
{
    /// <summary>
    /// Implementation of <see cref="ITaxRegionsRepository"/>
    /// </summary>
    public class TaxRegionsRepository : ITaxRegionsRepository
    {
        public List<RegionTax> TaxRegions { get; }

        /// <summary>
        /// Constructor that initializes the <see cref="TaxRegions"/> from <code>json</code>.
        /// </summary>
        /// <param name="json">The json string representing <see cref="RegionTax"/> that will populate the
        /// <see cref="TaxRegions"/></param>
        public TaxRegionsRepository(string json)
        {
            TaxRegions = JsonSerializer.Deserialize<List<RegionTax>>(json, new JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
        }
    }
}