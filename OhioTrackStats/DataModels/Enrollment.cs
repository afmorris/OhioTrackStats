// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Enrollment.cs" company="OhioTrackStats.com">
//   Copyright (c) 2018-2018 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace OhioTrackStats.DataModels
{
    using System;

    /// <summary>
    /// Represents a given school's enrollment for a specified year.
    /// </summary>
    public class Enrollment : BaseRecord
    {
        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the male enrollment.
        /// </summary>
        public int Male { get; set; }

        /// <summary>
        /// Gets or sets the female enrollment.
        /// </summary>
        public int Female { get; set; }

        /// <summary>
        /// Gets or sets the school identifier.
        /// </summary>
        public Guid SchoolId { get; set; }
    }
}