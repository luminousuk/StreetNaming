using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Http;
using StreetNaming.Util.DataAnnotations;

namespace StreetNaming.Web.ViewModels
{
    public class ExistingPropertyViewModel
    {
        [Display(Name = "Title")]
        [Required]
        public string ApplicantTitle { get; set; }

        [Display(Name = "Forename(s)")]
        public string ApplicantFirstName { get; set; }

        [Display(Name = "Surname")]
        [Required]
        public string ApplicantLastName { get; set; }

        public bool ApplicantUseSameAddress { get; set; }

        [Display(Name = "House Name/Number")]
        [RequiredIfBooleanPropertyFalse("ApplicantUseSameAddress")]
        public string ApplicantHouseNameNumber { get; set; }

        [Display(Name = "Street")]
        [RequiredIfBooleanPropertyFalse("ApplicantUseSameAddress")]
        public string ApplicantStreet { get; set; }

        [Display(Name = "Town")]
        [RequiredIfBooleanPropertyFalse("ApplicantUseSameAddress")]
        public string ApplicantTown { get; set; }

        [Display(Name = "County")]
        public string ApplicantCounty { get; set; }

        [Display(Name = "Post Code")]
        [RequiredIfBooleanPropertyFalse("ApplicantUseSameAddress")]
        [PostCode]
        public string ApplicantPostcode { get; set; }

        [Display(Name = "Telephone")]
        [RequiredGroup("ApplicantTelephone", "ApplicantMobile", "ApplicantEmail")]
        [Telephone]
        public string ApplicantTelephone { get; set; }

        [Display(Name = "Mobile")]
        [RequiredGroup("ApplicantTelephone", "ApplicantMobile", "ApplicantEmail")]
        public string ApplicantMobile { get; set; }

        [Display(Name = "Email")]
        [RequiredGroup("ApplicantTelephone", "ApplicantMobile", "ApplicantEmail")]
        [EmailAddress]
        public string ApplicantEmail { get; set; }

        [Display(Name = "Address")]
        public long ExistingPropertyUrn { get; set; }

        [Display(Name = "Address 1")]
        public string ProposedAddress1 { get; set; }

        [Display(Name = "Address 2")]
        public string ProposedAddress2 { get; set; }

        [Display(Name = "Address 3")]
        public string ProposedAddress3 { get; set; }

        public bool IsRegisteredOwner { get; set; }

        [Display(Name = "Attachments")]
        public IEnumerable<IFormFile> Attachments { get; set; }

        [Display(Name = "Signed")]
        public string Signed { get; set; }

        [Display(Name = "Date")]
        public string SignedDate { get; set; }

        public string AddressLookupEndpoint { get; set; }

        public int AddressLookupPageSize { get; set; }

        public int AddressLookupMinChars { get; set; }
    }
}