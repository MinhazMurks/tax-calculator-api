using System;
using System.Collections.Generic;
using System.Linq;
using TaxCalculator.Models;
using TaxCalculator.Repository;

namespace TaxCalculator.Services
{
    /// <summary>
    /// Implementation for <see cref="ITaxService"/>.
    /// </summary>
    public class TaxService : ITaxService
    {
        /// <summary>
        /// <see cref="ITaxRegionsRepository"/> that holds all <see cref="RegionTax"/>.
        /// </summary>
        private readonly ITaxRegionsRepository _taxRegionsRepository;

        /// <summary>
        /// Constructor to create a new <see cref="TaxService"/>.
        /// </summary>
        /// <param name="taxRegionsRepository">The <see cref="TaxRegionsRepository"/>.</param>
        public TaxService(ITaxRegionsRepository taxRegionsRepository)
        {
            this._taxRegionsRepository = taxRegionsRepository;
        }

        public RegionTax GetByZipCode(string zipCode)
        {
            List<RegionTax> matches = _taxRegionsRepository.TaxRegions.Where(taxRegion => taxRegion.ZipCode.Equals(zipCode)).ToList();
            if (matches.Any())
            {
                //First is returned since zip code is supposed to be unique, and it is in our database.
                return matches.First();
            }
            else
            {
                throw new ArgumentException($"No tax regions matched the zip code [{zipCode}]");
            }
        }
    }
}