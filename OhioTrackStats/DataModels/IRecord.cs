// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRecord.cs" company="OhioTrackStats.com">
//   Copyright (c) 2018-2018 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace OhioTrackStats.DataModels
{
    using System;

    /// <summary>
    /// The Database Record interface.
    /// </summary>
    public interface IRecord
    {
        /// <summary>
        /// Gets or sets the record's identifier.
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the inserted date.
        /// This is a computed field.
        /// </summary>
        DateTimeOffset InsertedDate { get; set; }

        /// <summary>
        /// Gets or sets the updated date.
        /// This is a computed field.
        /// </summary>
        DateTimeOffset UpdatedDate { get; set; }
    }
}