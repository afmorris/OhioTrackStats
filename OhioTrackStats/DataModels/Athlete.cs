// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Athlete.cs" company="OhioTrackStats.com">
//   Copyright (c) 2018-2018 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace OhioTrackStats.DataModels
{
    using System;

    using OhioTrackStats.Constants;

    /// <summary>
    /// Represents an athlete.
    /// </summary>
    public class Athlete : BaseRecord
    {
        /// <summary>
        /// Gets or sets the school identifier.
        /// </summary>
        public Guid SchoolId { get; set; }

        /// <summary>
        /// Gets or sets the year in which the athlete graduates.
        /// </summary>
        public int GraduationYear { get; set; }

        /// <summary>
        /// Gets or sets the athlete's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the athlete's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the athlete's gender.
        /// </summary>
        public Gender Gender { get; set; }
    }
}