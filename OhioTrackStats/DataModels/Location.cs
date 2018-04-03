// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Location.cs" company="OhioTrackStats.com">
//   Copyright (c) 2018-2018 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace OhioTrackStats.DataModels
{
    using System;

    /// <summary>
    /// Represents a physical location
    /// </summary>
    public class Location : BaseRecord
    {
        /// <summary>
        /// Gets or sets the first address line.
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// Gets or sets the second address line.
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the zip.
        /// </summary>
        public string Zip { get; set; }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (!(obj is Location item))
            {
                return false;
            }

            if (this.Id == Guid.Empty || item.Id == Guid.Empty)
            {
                return this.Address1 == item.Address1 && this.Address2 == item.Address2 && this.City == item.City && this.State == item.State && this.Zip == item.Zip;
            }

            return this.Id == item.Id && this.Address1 == item.Address1 && this.Address2 == item.Address2 && this.City == item.City && this.State == item.State && this.Zip == item.Zip;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.Address2))
            {
                return $"{this.Address1}{Environment.NewLine}{this.City}, {this.State} {this.Zip}";
            }

            return $"{this.Address1}{Environment.NewLine}{this.Address2}{Environment.NewLine}{this.City}, {this.State} {this.Zip}";
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return new { this.Address1, this.Address2, this.City, this.State, this.Zip }.GetHashCode();
        }
    }
}