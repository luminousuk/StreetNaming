using System.Collections.Generic;

namespace StreetNaming.Admin.ViewModels
{
    public class ApplicantListViewModel
    {
        public ICollection<ApplicantListApplicantViewModel> Applicants { get; set; }
    }
}