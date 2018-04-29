namespace OhioTrackStats.Grammar.Models
{
    public class IndividualResult : EventResult
    {
        public string AthleteName { get; set; }
        public int? AthleteYear { get; set; }

        public override string ToString()
        {
            return $"{this.Place} | {this.AthleteName} | {this.SchoolName} | {this.Performance.Data}";
        }
    }
}