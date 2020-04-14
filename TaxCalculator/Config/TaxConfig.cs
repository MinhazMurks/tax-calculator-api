﻿ namespace TaxCalculator.Config
{
    /// <summary>
    /// Implementation for <see cref="ITaxConfig"/>.
    /// </summary>
    public class TaxConfig : ITaxConfig
    {
        public string ZipCodePattern { get; set; }
        public string ZipCodePatternDescription { get; set; }
    }
}