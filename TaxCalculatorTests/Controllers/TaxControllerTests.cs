using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TaxCalculator.Controllers;
using TaxCalculator.Models;
using TaxCalculator.Responses;
using TaxCalculator.Services;
using TaxCalculator.Utilities;

namespace TaxCalculatorTests.Controllers
{
    /// <summary>
    /// Tests for <see cref="TaxController"/>.
    /// </summary>
    [TestClass]
    public class TaxControllerTests
    {
        private readonly MockRepository _mockRepository = new MockRepository(MockBehavior.Strict);
        
        private Mock<ITaxService> _mockTaxService;
        private Mock<ITaxCalculatorService> _mockTaxCalculatorService;
        private Mock<ITaxInputUtility> _mockTaxInputUtility;

        private TaxController _taxController;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockTaxService = _mockRepository.Create<ITaxService>();
            _mockTaxCalculatorService = _mockRepository.Create<ITaxCalculatorService>();
            _mockTaxInputUtility = _mockRepository.Create<ITaxInputUtility>();
            
            _taxController = new TaxController(_mockTaxService.Object, _mockTaxCalculatorService.Object, _mockTaxInputUtility.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _mockRepository.VerifyAll();
        }

        [TestMethod]
        public void TestGet_Successful()
        {
            string zipCode = "12345";
            string price = "4.75";
            
            RegionTax regionTax = new RegionTax() { State = "NC", ZipCode = "12345", EstimatedCombinedRate = .05f};
            TaxResponse taxResponse = new TaxResponse(4.75f, 4.99f, .05f);

            _mockTaxInputUtility.Setup(utility => utility.ValidateZipCode(It.Is<string>(value => value == zipCode)))
                .Returns(zipCode);
            _mockTaxInputUtility.Setup(utility => utility.ValidatePrice(It.Is<string>(value => value == price)))
                .Returns(4.75f);

            _mockTaxService.Setup(service => service.GetByZipCode(zipCode)).Returns(regionTax);

            _mockTaxCalculatorService.Setup(service =>
                    service.CalculateTax(It.Is<float>(f => f == 4.75f), It.Is<RegionTax>(tax => tax == regionTax)))
                .Returns(taxResponse);

            Assert.AreEqual(taxResponse, _taxController.Get(price, zipCode).Value);
        }
        
        [TestMethod]
        public void TestGet_InvalidPrice()
        {
            string zipCode = "12345";
            string price = "Invalid";
            
            string errorMessage = "Price [Invalid] is invalid, must be a floating point number.";
            ErrorResponse errorResponse = new ErrorResponse(errorMessage);
            
            _mockTaxInputUtility.Setup(utility => utility.ValidatePrice(It.Is<string>(value => value == price))).Throws(new ArgumentException(errorMessage));

            Assert.AreEqual(errorResponse, _taxController.Get(price, zipCode).Value);
        }
        
        [TestMethod]
        public void TestGet_InvalidZipCode()
        {
            string zipCode = "Invalid";
            string price = "4.75";
            
            string errorMessage = "Zip code [Invalid] is invalid, must be 5 digits.";
            ErrorResponse errorResponse = new ErrorResponse(errorMessage);

            _mockTaxInputUtility.Setup(utility => utility.ValidateZipCode(It.Is<string>(value => value == zipCode))).Throws(new ArgumentException(errorMessage));
            _mockTaxInputUtility.Setup(utility => utility.ValidatePrice(It.Is<string>(value => value == price)))
                .Returns(4.75f);

            Assert.AreEqual(errorResponse, _taxController.Get(price, zipCode).Value);
        }
        
        [TestMethod]
        public void TestGet_NoMatches()
        {
            string zipCode = "12345";
            string price = "4.75";
            
            string errorMessage = "No tax regions matched the zip code [12345].";
            ErrorResponse errorResponse = new ErrorResponse(errorMessage);

            _mockTaxInputUtility.Setup(utility => utility.ValidateZipCode(It.Is<string>(value => value == zipCode)))
                .Returns(zipCode);
            _mockTaxInputUtility.Setup(utility => utility.ValidatePrice(It.Is<string>(value => value == price)))
                .Returns(4.75f);

            _mockTaxService.Setup(service => service.GetByZipCode(zipCode)).Throws(new ArgumentException(errorMessage));

            Assert.AreEqual(errorResponse, _taxController.Get(price, zipCode).Value);
        }
    }
}