using System.ComponentModel.DataAnnotations;
using StreetNaming.Util.DataAnnotations;

namespace StreetNaming.Web.ViewModels
{
    public class NewPropertyViewModel
    {
        [Display(Name = "Title")]
        public string ApplicantTitle { get; set; }

        [Display(Name = "Forename(s)")]
        public string ApplicantFirstName { get; set; }

        [Display(Name = "Surname")]
        public string ApplicantLastName { get; set; }

        [Display(Name = "House Name/Number")]
        public string ApplicantHouseNameNumber { get; set; }

        [Display(Name = "Street")]
        public string ApplicantStreet { get; set; }

        [Display(Name = "Town")]
        public string ApplicantTown { get; set; }

        [Display(Name = "County")]
        public string ApplicantCounty { get; set; }

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

        [Display(Name = "Address 1")]
        public string ProposedAddress1 { get; set; }

        [Display(Name = "Address 2")]
        public string ProposedAddress2 { get; set; }

        [Display(Name = "Address 3")]
        public string ProposedAddress3 { get; set; }

        public bool IsRegisteredOwner { get; set; }

        [Display(Name = "Signed")]
        public string Signed { get; set; }

        [Display(Name = "Date")]
        public string SignedDate { get; set; }
    }
}