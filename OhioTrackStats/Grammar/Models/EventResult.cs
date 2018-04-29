namespace OhioTrackStats.Grammar.Models
{
    public class EventResult
    {
        public int Place { get; set; }
        public string SchoolName { get; set; }
        public Performance Seed { get; set; }
        public Performance Performance { get; set; }
        public int? HeatNumber { get; set; }
        public int? Points { get; set; }
        public Performance Tiebreaker { get; set; }
    }
}