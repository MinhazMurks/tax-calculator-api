using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxCalculator.Models;
using TaxCalculator.Repository;

namespace TaxCalculatorTests.Repository
{
    /// <summary>
    /// Tests for <see cref="TaxRegionsRepository"/>.
    /// </summary>
    [TestClass]
    public class TaxRegionsRepositoryTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            string jsonRegionTax = "[{" +
                                   "\"state\": \"NC\"," +
                                   "\"zipCode\": \"12345\"," +
                                   "\"taxRegionName\": \"raleigh\"," +
                                   "\"stateRate\": 0.0475," +
                                   "\"estimatedCombinedRate\": 0.0675," +
                                   "\"estimatedCountyRate\": 0.02," +
                                   "\"estimatedCityRate\": 0," +
                                   "\"estimatedSpecialRate\": 0," +
                                   "\"riskLevel\": 6" +
                                   "},{" +
                                   "\"state\": \"NC\"," +
                                   "\"zipCode\": \"54321\"," +
                                   "\"taxRegionName\": \"charlotte\"," +
                                   "\"stateRate\": 0.0475," +
                                   "\"estimatedCombinedRate\": 0.07," +
                                   "\"estimatedCountyRate\": 0.0225," +
                                   "\"estimatedCityRate\": 0," +
                                   "\"estimatedSpecialRate\": 0," +
                                   "\"riskLevel\": 2" +
                                   "}]";

            TaxRegionsRepository taxRegionsRepository = new TaxRegionsRepository(jsonRegionTax);

            RegionTax raleigh = new RegionTax
            {
                State = "NC",
                ZipCode = "12345",
                TaxRegionName = "raleigh",
                StateRate = 0.0475f,
                EstimatedCombinedRate = 0.0675f,
                EstimatedCountyRate = 0.02f,
                EstimatedCityRate = 0f,
                EstimatedSpecialRate = 0f,
                RiskLevel = 6
            };
            RegionTax charlotte = new RegionTax
            {
                State = "NC",
                ZipCode = "54321",
                TaxRegionName = "charlotte",
                StateRate = 0.0475f,
                EstimatedCombinedRate = 0.07f,
                EstimatedCountyRate = 0.0225f,
                EstimatedCityRate = 0f,
                EstimatedSpecialRate = 0f,
                RiskLevel = 2
            };
            List<RegionTax> regionTaxes = new List<RegionTax> {raleigh, charlotte};
            
            CollectionAssert.AreEqual(regionTaxes, taxRegionsRepository.TaxRegions);
        }
    }
}