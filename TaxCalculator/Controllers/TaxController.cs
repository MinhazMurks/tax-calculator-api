using System;
using Microsoft.AspNetCore.Mvc;
using TaxCalculator.Responses;
using TaxCalculator.Services;
using TaxCalculator.Utilities;

namespace TaxCalculator.Controllers
{
    /// <summary>
    /// API Controller for calculating taxes.
    /// </summary>
    [Route("api/v1/taxCalculator")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        private readonly ITaxService _taxService;
        private readonly ITaxCalculatorService _taxCalculatorService;
        private readonly ITaxInputUtility _taxInputUtility;

        /// <summary>
        /// Constructor to create a new <see cref="TaxController"/>.
        /// </summary>
        /// <param name="taxService">The <see cref="ITaxService"/> used to retrieve the tax regions.</param>
        /// <param name="taxCalculatorService">The <see cref="ITaxCalculatorService"/> used to calculate taxes.</param>
        /// <param name="taxInputUtility">The <see cref="ITaxInputUtility"/> used to validate inputs.</param>
        public TaxController(ITaxService taxService, ITaxCalculatorService taxCalculatorService, ITaxInputUtility taxInputUtility)
        {
            _taxService = taxService;
            _taxCalculatorService = taxCalculatorService;
            _taxInputUtility = taxInputUtility;
        }

        /// <summary>
        /// Get endpoint to calculate taxes.
        /// </summary>
        /// <param name="price">The price of the taxed object.</param>
        /// <param name="zipCode">The zip code of the region where the object was purchased.</param>
        /// <returns>A <see cref="JsonResult"/> of <see cref="TaxResponse"/> if a values are calculated successfully, <see cref="ErrorResponse"/> otherwise.</returns>
        [HttpGet]
        public JsonResult Get([FromQuery]string price, [FromQuery]string zipCode) // I decided to take params in as strings to allow validation to happen under my control
        {
            JsonResult response;
            try
            {
                response = new JsonResult(_taxCalculatorService.CalculateTax(_taxInputUtility.ValidatePrice(price), _taxService.GetByZipCode(_taxInputUtility.ValidateZipCode(zipCode))));
            }
            catch(ArgumentException e)
            {
                response = new JsonResult(new ErrorResponse(e.Message));
            }
            return response;
        }
    }
}