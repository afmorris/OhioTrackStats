// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PerformanceData.cs" company="OhioTrackStats.com">
//   Copyright (c) 2018-2018 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace OhioTrackStats.Models
{
    using System;

    using OhioTrackStats.DataModels;

    /// <summary>
    /// Represents an individual performance's data.
    /// </summary>
    public struct PerformanceData
    {
        /// <summary>
        /// Gets or sets the performance's time, if applicable.
        /// </summary>
        public TimeSpan Time { get; set; }

        /// <summary>
        /// Gets or sets the performance's distance, if applicable.
        /// </summary>
        public Distance Distance { get; set; }

        /// <summary>
        /// Instantiates the performance data object from the database data.
        /// </summary>
        /// <param name="data">
        /// The database data. Could be either time or distance.
        /// </param>
        /// <param name="event">
        /// The <see cref="TrackAndFieldEvent" /> that the data is set to.
        /// </param>
        /// <returns>
        /// The instantiated performance data.
        /// </returns>
        public static PerformanceData FromData(double data, TrackAndFieldEvent @event)
        {
            if (@event.IsRunningEvent)
            {
                return new PerformanceData { Distance = default(Distance), Time = TimeSpan.FromSeconds(data) };
            }

            return new PerformanceData
            {
                Distance = new Distance
                {
                    Feet = (int)Math.Floor(data / 12),
                    Inches = data % 12
                },
                Time = default(TimeSpan)
            };
        }
    }
}