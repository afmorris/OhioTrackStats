// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BulkViewModel.cs" company="OhioTrackStats.com">
//   Copyright (c) 2018-2018 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using OhioTrackStats.DataModels;

namespace OhioTrackStats.ViewModels.Admin
{
    public class BulkViewModel
    {
        /// <summary>
        /// Gets or sets the collection of <see cref="TrackAndFieldEvent" /> instances.
        /// </summary>
        public IList<TrackAndFieldEvent> Events { get; set; } = new List<TrackAndFieldEvent>();
    }
}