using System.Collections.Generic;

namespace OhioTrackStats.Grammar.Models
{
    public class LegInfo
    {
        public IList<Leg> Legs { get; set; } = new List<Leg>();
    }
}