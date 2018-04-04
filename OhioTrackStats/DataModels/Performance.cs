// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Performance.cs" company="OhioTrackStats.com">
//   Copyright (c) 2018-2018 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using ServiceStack.DataAnnotations;

namespace OhioTrackStats.DataModels
{
    using System;

    using OhioTrackStats.Constants;

    /// <summary>
    /// Represents a performance by an athlete.
    /// </summary>
    public class Performance : BaseRecord
    {
        /// <summary>
        /// Gets or sets the event identifier for the performance.
        /// </summary>
        [References(typeof(TrackAndFieldEvent))]
        public Guid EventId { get; set; }

        /// <summary>
        /// Gets or sets the school identifier for the performance.
        /// </summary>
        public Guid SchoolId { get; set; }

        /// <summary>
        /// Gets or sets the meet identifier in which the performance occurred.
        /// </summary>
        public Guid MeetId { get; set; }

        /// <summary>
        /// Gets or sets the performance's data. This can be two different things.
        /// If the event is a running event, it is the time in seconds.
        /// If the event is a field event, it is the height/distance in inches.
        /// </summary>
        public decimal Data { get; set; }

        /// <summary>
        /// Gets or sets the date in which the performance occurred.
        /// </summary>
        public DateTimeOffset Date { get; set; }

        /// <summary>
        /// Gets or sets the event's timing method.
        /// </summary>
        public TimingMethod TimingMethod { get; set; }

        /// <summary>
        /// Gets or sets the performance's notes.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the performance's computed score.
        /// </summary>
        public decimal ComputedScore { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the performance was approved.
        /// </summary>
        public bool Approved { get; set; }

        /// <summary>
        /// Gets or sets the date of the approval.
        /// </summary>
        public DateTimeOffset ApprovalDate { get; set; }

        public bool NeedsAssociated { get; set; }

        [Reference]
        public TrackAndFieldEvent Event { get; set; }

        [Reference]
        public School School { get; set; }

        [Reference]
        public Meet Meet { get; set; }
    }
}