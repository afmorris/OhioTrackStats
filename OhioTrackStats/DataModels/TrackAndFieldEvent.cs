// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TrackAndFieldEvent.cs" company="OhioTrackStats.com">
//   Copyright (c) 2018-2018 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using ServiceStack.DataAnnotations;

namespace OhioTrackStats.DataModels
{
    using OhioTrackStats.Constants;

    /// <summary>
    /// Represents an event in track and field.
    /// </summary>
    public class TrackAndFieldEvent : BaseRecord
    {
        /// <summary>
        /// Gets or sets the event's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the event's name, simplified for use.
        /// </summary>
        public string SafeName { get; set; }

        /// <summary>
        /// Gets or sets the event's gender.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this event is a running event.
        /// </summary>
        public bool IsRunningEvent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this event is a relay event.
        /// </summary>
        public bool IsRelayEvent { get; set; }

        /// <summary>
        /// Gets or sets the order to display the event.
        /// </summary>
        public int Order { get; set; }
    }
}