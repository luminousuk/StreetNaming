using System;
using System.ComponentModel.DataAnnotations;
using StreetNaming.Util.DataAnnotations;

namespace StreetNaming.Web.ViewModels
{
    public class ExistingPropertyViewModel
    {
        [Display(Name = "Name")]
        public string ApplicantName { get; set; }

        [Display(Name = "Address")]
        public string ApplicantAddress { get; set; }

        [Display(Name = "Post Code")]
        [PostCode]
        public string ApplicantPostcode { get; set; }

        [Display(Name = "Telephone")]
        [Telephone]
        public string ApplicantTelephone { get; set; }

        [Display(Name = "Mobile")]
        public string ApplicantMobile { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        public string ApplicantEmail { get; set; }

        [Display(Name = "Address")]
        public string CurrentAddress { get; set; }

        [Display(Name = "Proposed Address 1")]
        public string ProposedAddress1 { get; set; }

        [Display(Name = "Proposed Address 2")]
        public string ProposedAddress2 { get; set; }

        [Display(Name = "Proposed Address 3")]
        public string ProposedAddress3 { get; set; }

        public bool IsRegisteredOwner { get; set; }

        [Display(Name = "Signed")]
        public string Signed { get; set; }

        [Display(Name = "Date")]
        public DateTime SignedDate { get; set; }
    }
}