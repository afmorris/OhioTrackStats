// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseRecord.cs" company="OhioTrackStats.com">
//   Copyright (c) 2018-2018 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace OhioTrackStats.DataModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Represents the abstract base record for all database records.
    /// </summary>
    public abstract class BaseRecord : IRecord
    {
        /// <inheritdoc />
        [Key]
        public Guid Id { get; set; }

        /// <inheritdoc />
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset InsertedDate { get; set; }

        /// <inheritdoc />
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset UpdatedDate { get; set; }
    }
}