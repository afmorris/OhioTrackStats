// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Conference.cs" company="OhioTrackStats.com">
//   Copyright (c) 2018-2018 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace OhioTrackStats.DataModels
{
    /// <summary>
    /// Represents a conference that schools are a part of.
    /// </summary>
    public class Conference : BaseRecord
    {
        /// <summary>
        /// Gets or sets the conference name.
        /// </summary>
        public string Name { get; set; }
    }
}