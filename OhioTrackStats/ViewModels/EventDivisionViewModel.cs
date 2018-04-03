// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventDivisionViewModel.cs" company="OhioTrackStats.com">
//   Copyright (c) 2018-2018 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace OhioTrackStats.ViewModels
{
    using System.Collections.Generic;

    using OhioTrackStats.DataModels;

    /// <summary>
    /// Represents a given division's leaderboard.
    /// </summary>
    public class EventDivisionViewModel
    {
        /// <summary>
        /// Gets or sets the division.
        /// </summary>
        public string Division { get; set; }

        /// <summary>
        /// Gets or sets the collection of Performances.
        /// </summary>
        public IList<PerformanceView> Performances { get; set; } = new List<PerformanceView>();
    }
}