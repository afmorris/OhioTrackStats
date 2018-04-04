// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DivisionEnrollment.cs" company="OhioTrackStats.com">
//   Copyright (c) 2018-2018 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using ServiceStack.DataAnnotations;

namespace OhioTrackStats.DataModels
{
    using System;

    /// <summary>
    /// Represents the division enrollment breakdown for a given year
    /// </summary>
    public class DivisionEnrollment : BaseRecord
    {
        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the maximum male enrollment for the division.
        /// </summary>
        public int MaleMax { get; set; }

        /// <summary>
        /// Gets or sets the minimum male enrollment for the division.
        /// </summary>
        public int MaleMin { get; set; }

        /// <summary>
        /// Gets or sets the maximum female enrollment for the division.
        /// </summary>
        public int FemaleMax { get; set; }

        /// <summary>
        /// Gets or sets the minimum female enrollment for the division.
        /// </summary>
        public int FemaleMin { get; set; }

        /// <summary>
        /// Gets or sets the division identifier.
        /// </summary>
        public Guid DivisionId { get; set; }

        [Reference]
        public Division Division { get; set; }
    }
}