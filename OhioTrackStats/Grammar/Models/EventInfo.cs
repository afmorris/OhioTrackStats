namespace OhioTrackStats.Grammar.Models
{
    public class EventInfo
    {
        public int Number { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{this.Name} | {this.Gender}";
        }
    }
}