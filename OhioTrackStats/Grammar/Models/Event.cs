using System.Collections.Generic;

namespace OhioTrackStats.Grammar.Models
{
    public class Event
    {
        public EventInfo EventInfo { get; set; } = new EventInfo();
        public string EventHeader { get; set; }
        public IList<EventResult> EventResults { get; set; } = new List<EventResult>();

        public override string ToString()
        {
            return $"{this.EventInfo} | {this.EventResults.Count} Results";
        }
    }
}