// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DivisionAssignment.cs" company="OhioTrackStats.com">
//   Copyright (c) 2018-2018 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace OhioTrackStats.DataModels
{
    using System;

    using OhioTrackStats.Constants;

    /// <summary>
    /// Represents the association between a division and a school for a given <see cref="Gender" /> and year.
    /// </summary>
    public class DivisionAssignment : BaseRecord
    {
        /// <summary>
        /// Gets or sets the division identifier.
        /// </summary>
        public Guid DivisionId { get; set; }

        /// <summary>
        /// Gets or sets the school identifier.
        /// </summary>
        public Guid SchoolId { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        public int Year { get; set; }
    }
}