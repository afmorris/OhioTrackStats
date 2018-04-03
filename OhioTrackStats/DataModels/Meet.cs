// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Meet.cs" company="OhioTrackStats.com">
//   Copyright (c) 2018-2018 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace OhioTrackStats.DataModels
{
    using System;

    /// <summary>
    /// Represents a meet that performances occur at.
    /// </summary>
    public class Meet : BaseRecord
    {
        /// <summary>
        /// Gets or sets the meet's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the location identifier for the meet.
        /// </summary>
        public Guid LocationId { get; set; }

        /// <summary>
        /// Gets or sets the date of the meet.
        /// </summary>
        public DateTimeOffset Date { get; set; }
    }
}