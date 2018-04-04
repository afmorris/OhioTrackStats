using System.ComponentModel;

namespace OhioTrackStats.ViewModels.Admin
{
    public class LocationEntryViewModel
    {
        [DisplayName("Address Line 1")]
        public string Address1 { get; set; }

        [DisplayName("Address Line 2")]
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}