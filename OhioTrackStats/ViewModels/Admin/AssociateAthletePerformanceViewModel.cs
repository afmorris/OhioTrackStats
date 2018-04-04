using System;
using System.Collections.Generic;
using OhioTrackStats.DataModels;

namespace OhioTrackStats.ViewModels.Admin
{
    public class AssociateAthletePerformanceViewModel
    {
        public IList<Performance> Performances { get; set; } = new List<Performance>();
        public IList<Athlete> Athletes { get; set; } = new List<Athlete>();

        public Guid SelectedPerformanceId { get; set; }
        public Guid SelectedAthleteId { get; set; }
    }
}