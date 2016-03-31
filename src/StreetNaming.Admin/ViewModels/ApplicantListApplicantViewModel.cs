using System;
using System.ComponentModel.DataAnnotations;

namespace StreetNaming.Admin.ViewModels
{
    public class ApplicantListApplicantViewModel
    {
        public int ApplicantId { get; set; }

        [Display(Name = "Name")]
        public string FullName { get; set; }

        [Display(Name = "Address")]
        public string FullAddress { get; set; }

        [Display(Name = "Telephone")]
        public string Telephone { get; set; }

        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Created")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Cases")]
        public int CaseCount { get; set; }
    }
}