﻿using System;
 
 namespace TaxCalculator.Models
{
    /// <summary>
    /// Model representing a regional tax.
    /// </summary>
    public class RegionTax
    {
        /// <summary>
        /// Two letter abbreviation of the state of the tax.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Five digit zip code of the area of the tax.
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// The name of the tax region, lowercase and separated by dashes.
        /// </summary>
        public string TaxRegionName { get; set; }

        /// <summary>
        /// The tax rate of the state.
        /// </summary>
        public float StateRate { get; set; }

        /// <summary>
        /// The estimated tax rate of all of the tax rates combined.
        /// </summary>
        public float EstimatedCombinedRate { get; set; }

        /// <summary>
        /// The estimated tax rate of the county.
        /// </summary>
        public float EstimatedCountyRate { get; set; }

        /// <summary>
        /// The estimated tax rate of the city.
        /// </summary>
        public float EstimatedCityRate { get; set; }

        /// <summary>
        /// The estimated special tax rate.
        /// </summary>
        public float EstimatedSpecialRate { get; set; }

        /// <summary>
        /// The risk level of retrieving tax rate based on zip code.
        /// </summary>
        public int RiskLevel { get; set; }

        protected bool Equals(RegionTax other)
        {
            return State == other.State && ZipCode == other.ZipCode && TaxRegionName == other.TaxRegionName &&
                   StateRate.Equals(other.StateRate) && EstimatedCombinedRate.Equals(other.EstimatedCombinedRate) &&
                   EstimatedCountyRate.Equals(other.EstimatedCountyRate) &&
                   EstimatedCityRate.Equals(other.EstimatedCityRate) &&
                   EstimatedSpecialRate.Equals(other.EstimatedSpecialRate) && RiskLevel == other.RiskLevel;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RegionTax) obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(State);
            hashCode.Add(ZipCode);
            hashCode.Add(TaxRegionName);
            hashCode.Add(StateRate);
            hashCode.Add(EstimatedCombinedRate);
            hashCode.Add(EstimatedCountyRate);
            hashCode.Add(EstimatedCityRate);
            hashCode.Add(EstimatedSpecialRate);
            hashCode.Add(RiskLevel);
            return hashCode.ToHashCode();
        }
    }
}