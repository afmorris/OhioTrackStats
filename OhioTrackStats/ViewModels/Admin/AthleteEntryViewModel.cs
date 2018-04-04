// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AthleteEntryViewModel.cs" company="OhioTrackStats.com">
//   Copyright (c) 2018-2018 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using OhioTrackStats.DataModels;

namespace OhioTrackStats.ViewModels.Admin
{
    public class AthleteEntryViewModel
    {
        /// <summary>
        /// Gets or sets the collection of <see cref="School" /> instances.
        /// </summary>
        public IList<School> Schools { get; set; } = new List<School>();

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Gender")]
        public string Gender { get; set; }

        [DisplayName("Graduation Year")]
        public int? GraduationYear { get; set; }

        /// <summary>
        /// Gets or sets the selected school identifier.
        /// </summary>
        [DisplayName("School")]
        public Guid SelectedSchoolId { get; set; }
    }
}