using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxCalculator.Models;
using TaxCalculator.Responses;
using TaxCalculator.Services;

namespace TaxCalculatorTests.Services
{
    /// <summary>
    /// Tests for <see cref="TaxCalculatorService"/>.
    /// </summary>
    [TestClass]
    public class TaxCalculatorServiceTests
    {
        private TaxCalculatorService _taxCalculatorService = new TaxCalculatorService();
        
        [DynamicData(nameof(ProvideCalculateTaxArguments))]
        [TestMethod]
        public void TestCalculateTax(float expectedFullPrice, float price, RegionTax regionTax)
        {
            TaxResponse response = _taxCalculatorService.CalculateTax(price, regionTax);
            Assert.AreEqual(expectedFullPrice, response.FullPrice);
            Assert.AreEqual(price, response.OriginalPrice);
            Assert.AreEqual(regionTax.EstimatedCombinedRate, response.TaxRate);
        }
        
        private static IEnumerable<object[]> ProvideCalculateTaxArguments
        {
            get
            {
                return new[]
                {
                    new object[]
                    {
                        6.18125f, 5.75f,
                        new RegionTax() {State = "NC", ZipCode = "12345", EstimatedCombinedRate = .075f}
                    },
                    new object[]
                    {
                        5.25f, 5.00f,
                        new RegionTax() {State = "NC", ZipCode = "32574", EstimatedCombinedRate = .05f}
                    },
                };
            }
        }
    }
}