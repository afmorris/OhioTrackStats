using System;
using System.Collections.Generic;
using System.ComponentModel;
using OhioTrackStats.DataModels;

namespace OhioTrackStats.ViewModels.Admin
{
    public class MeetEntryViewModel
    {
        public IList<Location> Locations { get; set; } = new List<Location>();
        public IList<Meet> Meets { get; set; } = new List<Meet>();

        [DisplayName("Location")]
        public Guid SelectedLocationId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}