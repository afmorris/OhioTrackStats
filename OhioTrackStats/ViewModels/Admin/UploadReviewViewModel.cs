using System.Collections.Generic;
using OhioTrackStats.DataModels;

namespace OhioTrackStats.ViewModels.Admin
{
    public class UploadReviewViewModel
    {
        public Meet Meet { get; set; } = new Meet();
        public IList<EventViewModel> Events { get; set; } = new List<EventViewModel>();
        public string Error { get; set; }
    }
}