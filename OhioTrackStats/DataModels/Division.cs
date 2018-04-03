// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Division.cs" company="OhioTrackStats.com">
//   Copyright (c) 2018-2018 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace OhioTrackStats.DataModels
{
    /// <summary>
    /// Represents the division a school can be in.
    /// </summary>
    public class Division : BaseRecord
    {
        /// <summary>
        /// Gets or sets the division name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the order in which to display and sort the division.
        /// </summary>
        public int Order { get; set; }
    }
}