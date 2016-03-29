using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StreetNaming.Admin.ViewModels
{
    public class ApplicantListViewModel
    {
        public ICollection<ApplicantListApplicantViewModel> Applicants { get; set; }
    }
}