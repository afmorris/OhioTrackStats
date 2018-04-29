using System.Collections.Generic;
using OhioTrackStats.DataModels;

namespace OhioTrackStats.ViewModels.Admin
{
    public class PerformanceViewModel
    {
        public Performance Performance { get; set; }
        public IList<Athlete> Athletes { get; set; } = new List<Athlete>();
    }
}