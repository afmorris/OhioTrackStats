using System;
using System.Collections.Generic;
using System.ComponentModel;
using OhioTrackStats.DataModels;

namespace OhioTrackStats.ViewModels.Admin
{
    public class UploadFileViewModel
    {
        [DisplayName("Meet Name")]
        public string MeetName { get; set; }

        [DisplayName("Meet Date")]
        public DateTimeOffset MeetDate { get; set; }

        [DisplayName("Schools")]
        public IList<Guid> SelectedSchoolIds { get; set; } = new List<Guid>();

        [DisplayName("School Translation")]
        public string SchoolTranslation { get; set; } = string.Empty;

        public IList<School> Schools { get; set; } = new List<School>();
    }
}