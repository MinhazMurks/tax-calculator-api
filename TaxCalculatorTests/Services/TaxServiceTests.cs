using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TaxCalculator.Models;
using TaxCalculator.Repository;
using TaxCalculator.Services;

namespace TaxCalculatorTests.Services
{
    /// <summary>
    /// Tests for <see cref="TaxService"/>.
    /// </summary>
    [TestClass]
    public class TaxServiceTests
    {
        private readonly MockRepository _mockRepository = new MockRepository(MockBehavior.Strict);
        private readonly RegionTax _raleigh = new RegionTax {State = "NC", ZipCode = "12345", EstimatedCombinedRate = .075f};
        private readonly RegionTax _charlotte = new RegionTax {State = "NC", ZipCode = "54321", EstimatedCombinedRate = .081f};
        
        private Mock<ITaxRegionsRepository> _mockTaxRegionsRepository;
        private TaxService _taxService;

        [TestInitialize]
        public void TestInitialize()
        {
            List<RegionTax> regionTaxes = new List<RegionTax> {_raleigh, _charlotte};

            _mockTaxRegionsRepository = _mockRepository.Create<ITaxRegionsRepository>();
            _mockTaxRegionsRepository.SetupGet(repository => repository.TaxRegions).Returns(regionTaxes);
            
            _taxService = new TaxService(_mockTaxRegionsRepository.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _mockRepository.VerifyAll();
        }

        [TestMethod]
        public void TestGetByZipCode_Valid()
        {
            Assert.AreSame(_raleigh, _taxService.GetByZipCode("12345"));
        }

        [TestMethod]
        public void TestGetByZipCode_NoMatches()
        {
            try
            {
                _taxService.GetByZipCode("54321");
            }
            catch (ArgumentException exception)
            {
                Assert.AreEqual("No tax regions matched the zip code [99999]", exception.Message);
            }
        }
    }
}