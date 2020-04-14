using System.Collections.Generic;
using TaxCalculator.Models;

namespace TaxCalculator.Repository
{
    /// <summary>
    /// This class is meant to represent a database and a library interfacing with it. For convenience when actually
    /// launching the application, I decided not to create a real database.
    /// </summary>
    public interface ITaxRegionsRepository
    {
        /// <summary>
        /// List of all <see cref="RegionTax"/>.
        /// </summary>
        public List<RegionTax> TaxRegions { get; }
    }
}