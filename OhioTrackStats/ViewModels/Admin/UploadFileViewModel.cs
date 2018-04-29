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
        public IList<Guid> SelectedSchoolIds { get; set; }

        [DisplayName("School Translation")]
        public string SchoolTranslation { get; set; }
        public IList<School> Schools { get; set; }
    }
}