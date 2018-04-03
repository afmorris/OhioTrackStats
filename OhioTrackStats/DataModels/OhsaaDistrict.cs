// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OhsaaDistrict.cs" company="OhioTrackStats.com">
//   Copyright (c) 2018-2018 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace OhioTrackStats.DataModels
{
    /// <summary>
    /// Represents an OHSAA district that a school is part of.
    /// </summary>
    public class OhsaaDistrict : BaseRecord
    {
        /// <summary>
        /// Gets or sets the name of the OHSAA district.
        /// </summary>
        public string Name { get; set; }
    }
}