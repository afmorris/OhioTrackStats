using System.Collections.Generic;
using OhioTrackStats.DataModels;

namespace OhioTrackStats.Models
{
    public class EventPerformance
    {
        public TrackAndFieldEvent Event { get; set; }
        public IList<Athlete> Athletes { get; set; } = new List<Athlete>();

    }
}