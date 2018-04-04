using System;
using System.Collections.Generic;
using System.ComponentModel;
using OhioTrackStats.DataModels;

namespace OhioTrackStats.ViewModels.Admin
{
    public class AssociateAthletePerformanceViewModel
    {
        public IList<Performance> Performances { get; set; } = new List<Performance>();
        public IList<Athlete> Athletes { get; set; } = new List<Athlete>();

        [DisplayName("Performance")]
        public Guid SelectedPerformanceId { get; set; }

        [DisplayName("Athlete")]
        public Guid SelectedAthleteId { get; set; }
    }
}