// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventViewModel.cs" company="OhioTrackStats.com">
//   Copyright (c) 2018-2018 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace OhioTrackStats.ViewModels
{
    using System.Collections.Generic;

    using OhioTrackStats.DataModels;

    /// <summary>
    /// Represents the data that is displayed on the event page.
    /// </summary>
    public class EventViewModel
    {
        /// <summary>
        /// Gets or sets the <see cref="TrackAndFieldEvent" /> that is being displayed.
        /// </summary>
        public TrackAndFieldEvent Event { get; set; }

        /// <summary>
        /// Gets or sets the collection of <see cref="EventDivisionViewModel" /> to bind to the front end.
        /// </summary>
        public IList<EventDivisionViewModel> EventDivisions { get; set; } = new List<EventDivisionViewModel>();
    }
}