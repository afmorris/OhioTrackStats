// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Distance.cs" company="OhioTrackStats.com">
//   Copyright (c) 2018-2018 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace OhioTrackStats.Models
{
    /// <summary>
    /// Represents the distance for a field event performance.
    /// </summary>
    public struct Distance
    {
        /// <summary>
        /// Gets or sets the feet component of the distance.
        /// </summary>
        public int Feet { get; set; }

        /// <summary>
        /// Gets or sets the inches component of the distance.
        /// </summary>
        public double Inches { get; set; }
    }
}