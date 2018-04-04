// --------------------------------------------------------------------------------------------------------------------
// <copyright file="School.cs" company="OhioTrackStats.com">
//   Copyright (c) 2018-2018 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using ServiceStack.DataAnnotations;

namespace OhioTrackStats.DataModels
{
    using System;
    using System.Drawing;

    using OhioTrackStats.Constants;

    /// <summary>
    /// Represents a school
    /// </summary>
    public class School : BaseRecord
    {
        /// <summary>
        /// Gets or sets the name of the school.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the OHSAA identifier of the school.
        /// </summary>
        public int OhsaaId { get; set; }

        /// <summary>
        /// Gets or sets the conference identifier.
        /// </summary>
        public Guid ConferenceId { get; set; }

        /// <summary>
        /// Gets or sets the location identifier.
        /// </summary>
        public Guid LocationId { get; set; }

        /// <summary>
        /// Gets or sets the phone number for the school.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the fax number for the school.
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// Gets or sets the school's website.
        /// </summary>
        public Uri Website { get; set; }

        /// <summary>
        /// Gets or sets the county's identifier.
        /// </summary>
        public Guid CountyId { get; set; }

        /// <summary>
        /// Gets or sets the OHSAA District identifier.
        /// </summary>
        public Guid OhsaaDistrictId { get; set; }

        /// <summary>
        /// Gets or sets the OHSAA tournament name.
        /// </summary>
        public string OhsaaTournamentName { get; set; }

        /// <summary>
        /// Gets or sets the school's primary color.
        /// </summary>
        public Color PrimaryColor { get; set; }

        /// <summary>
        /// Gets or sets the school's secondary color.
        /// </summary>
        public Color SecondaryColor { get; set; }

        /// <summary>
        /// Gets or sets the school's tertiary color.
        /// </summary>
        public Color TertiaryColor { get; set; }

        /// <summary>
        /// Gets or sets the school's mascot for males.
        /// </summary>
        public string MaleMascot { get; set; }

        /// <summary>
        /// Gets or sets the school's mascot for females.
        /// </summary>
        public string FemaleMascot { get; set; }

        /// <summary>
        /// Gets or sets the school's type.
        /// </summary>
        public SchoolType SchoolType { get; set; }

        [Reference]
        public Conference Conference { get; set; }

        [Reference]
        public Location Location { get; set; }

        [Reference]
        public County County { get; set; }

        [Reference]
        public OhsaaDistrict OhsaaDistrict { get; set; }
    }
}