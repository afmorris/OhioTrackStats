// --------------------------------------------------------------------------------------------------------------------
// <copyright file="County.cs" company="OhioTrackStats.com">
//   Copyright (c) 2018-2018 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace OhioTrackStats.DataModels
{
    /// <summary>
    /// Represents the physical county the school is located in.
    /// </summary>
    public class County : BaseRecord
    {
        /// <summary>
        /// Gets or sets the county's name.
        /// </summary>
        public string Name { get; set; }
    }
}