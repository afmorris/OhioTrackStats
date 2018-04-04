using System;
using System.Collections.Generic;
using System.ComponentModel;
using OhioTrackStats.DataModels;
using OhioTrackStats.Models;

namespace OhioTrackStats.ViewModels.Admin
{
    public class PerformanceEntryViewModel
    {
        public IList<TrackAndFieldEvent> Events { get; set; } = new List<TrackAndFieldEvent>();
        public IList<School> Schools { get; set; } = new List<School>();
        public IList<Meet> Meets { get; set; } = new List<Meet>();

        [DisplayName("Event")]
        public Guid SelectedEventId { get; set; }

        [DisplayName("School")]
        public Guid SelectedSchoolId { get; set; }

        [DisplayName("Meet")]
        public Guid SelectedMeetId { get; set; }

        public decimal Data { get; set; }
        public DateTimeOffset Date { get; set; }

        [DisplayName("Timing Method")]
        public string TimingMethod { get; set; }

        public string Notes { get; set; }
    }
}