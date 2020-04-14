using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TaxCalculator.Config;
using TaxCalculator.Utilities;

namespace TaxCalculatorTests.Utilities
{
    [TestClass]
    public class TaxInputUtilityTests
    {
        private readonly MockRepository _mockRepository = new MockRepository(MockBehavior.Strict);
        private Mock<ITaxConfig> _mockTaxConfig;
        private TaxInputUtility _taxInputUtility;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockTaxConfig = _mockRepository.Create<ITaxConfig>();
            _taxInputUtility = new TaxInputUtility(_mockTaxConfig.Object);
        }
        
        [TestCleanup]
        public void TestCleanup()
        {
            _mockRepository.VerifyAll();
        }
        
        [DataRow(100f, "100")]
        [DataRow(2.74f, "  2.74   ")]
        [DataRow(0f, "0")]
        [DataRow(-2.74f, "-2.74")]
        [DataRow(99999999999999999f, "99999999999999999")]
        [DataTestMethod]
        public void TestValidatePrice_Valid(float expectedPrice, string price)
        {
            Assert.AreEqual(expectedPrice, _taxInputUtility.ValidatePrice(price));
        }
        
        [DataRow(null)]
        [DataRow("sldf123")]
        [DataRow("abcd")]
        [DataRow("4.2f")]
        [DataTestMethod]
        public void TestValidatePrice_Invalid(string price)
        {
            try
            {
                _taxInputUtility.ValidatePrice(price);
                Assert.Fail("ArgumentException was not thrown on invalid input.");
            }
            catch (ArgumentException exception)
            {
                Assert.AreEqual($"Price [{price}] is invalid, must be a floating point number.", exception.Message);
            }
        }

        [TestMethod]
        public void TestValidatePrice_Null()
        {
            try
            {
                _taxInputUtility.ValidatePrice(null);
                Assert.Fail("ArgumentException was not thrown on invalid input.");
            }
            catch (ArgumentException exception)
            {
                Assert.AreEqual($"Price [] is invalid, must be a floating point number.", exception.Message);
            }
        }
        
        [DataRow("12345", "12345")]
        [DataRow("12345", "    12345    ")]
        [DataTestMethod]
        public void TestValidateZipCode_Valid(string expectedZipCode, string zipCode)
        {
            _mockTaxConfig.SetupGet(config => config.ZipCodePattern).Returns("^\\d\\d\\d\\d\\d$");
            Assert.AreEqual(expectedZipCode, _taxInputUtility.ValidateZipCode(zipCode));
        }
        
        [DataRow("")]
        [DataRow("klsdd")]
        [DataRow("klsddkl")]
        [DataRow("1234")]
        [DataRow("123456")]
        [DataTestMethod]
        public void TestValidateZipCode_Invalid(string zipCode)
        {
            _mockTaxConfig.SetupGet(config => config.ZipCodePattern).Returns("^\\d\\d\\d\\d\\d$");
            _mockTaxConfig.SetupGet(config => config.ZipCodePatternDescription).Returns("5 digits");
            try
            {
                _taxInputUtility.ValidateZipCode(zipCode);
                Assert.Fail("ArgumentException was not thrown on invalid input.");
            }
            catch (ArgumentException exception)
            {
                Assert.AreEqual($"Zip code [{zipCode}] is invalid, must be 5 digits.", exception.Message);
            }
        }
        
        [TestMethod]
        public void TestValidateZipCode_Null()
        {
            _mockTaxConfig.SetupGet(config => config.ZipCodePatternDescription).Returns("5 digits");
            try
            {
                _taxInputUtility.ValidateZipCode(null);
                Assert.Fail("ArgumentException was not thrown on invalid input.");
            }
            catch (ArgumentException exception)
            {
                Assert.AreEqual($"Zip code [] is invalid, must be 5 digits.", exception.Message);
            }
        }
    }
}