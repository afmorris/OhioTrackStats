namespace OhioTrackStats.Grammar.Models
{
    public class RelayResult : EventResult
    {
        public LegInfo LegInfo { get; set; }

        public override string ToString()
        {
            return $"{this.Place} | {this.SchoolName} | {this.Performance.Data}";
        }
    }
}