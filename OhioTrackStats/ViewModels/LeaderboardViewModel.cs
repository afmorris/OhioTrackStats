// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LeaderboardViewModel.cs" company="OhioTrackStats.com">
//   Copyright (c) 2018-2018 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace OhioTrackStats.ViewModels
{
    using System.Collections.Generic;

    using OhioTrackStats.DataModels;

    /// <summary>
    /// Represents the data that is displayed on the Leaderboard page.
    /// </summary>
    public class LeaderboardViewModel
    {
        /// <summary>
        /// Gets or sets the male events for the leaderboard.
        /// </summary>
        public IList<TrackAndFieldEvent> MaleEvents { get; set; }

        /// <summary>
        /// Gets or sets the female events for the leaderboard.
        /// </summary>
        public IList<TrackAndFieldEvent> FemaleEvents { get; set; }
    }
}