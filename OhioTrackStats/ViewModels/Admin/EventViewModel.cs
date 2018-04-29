using System.Collections.Generic;
using OhioTrackStats.DataModels;

namespace OhioTrackStats.ViewModels.Admin
{
    public class EventViewModel
    {
        public TrackAndFieldEvent Event { get; set; }
        public IList<PerformanceViewModel> Performances { get; set; } = new List<PerformanceViewModel>();
    }
}