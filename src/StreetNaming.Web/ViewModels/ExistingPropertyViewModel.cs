﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc.Rendering;
using StreetNaming.Util.DataAnnotations;

namespace StreetNaming.Web.ViewModels
{
    public class ExistingPropertyViewModel
    {
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Please select your Title.")]
        public string ApplicantTitle { get; set; }

        [Display(Name = "Forename(s)")]
        public string ApplicantFirstName { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Please enter your Surname.")]
        public string ApplicantLastName { get; set; }

        public bool ApplicantUseSameAddress { get; set; }

        [Display(Name = "House Name/Number")]
        [RequiredIfBooleanPropertyFalse("ApplicantUseSameAddress", ErrorMessage = "Please enter your house name/number.")]
        public string ApplicantHouseNameNumber { get; set; }

        [Display(Name = "Street")]
        [RequiredIfBooleanPropertyFalse("ApplicantUseSameAddress", ErrorMessage = "Please enter your Street.")]
        public string ApplicantStreet { get; set; }

        [Display(Name = "Town")]
        [RequiredIfBooleanPropertyFalse("ApplicantUseSameAddress", ErrorMessage = "Please enter your Town.")]
        public string ApplicantTown { get; set; }

        [Display(Name = "County")]
        public string ApplicantCounty { get; set; }

        [Display(Name = "Post Code")]
        [RequiredIfBooleanPropertyFalse("ApplicantUseSameAddress", ErrorMessage = "Please enter a valid UK Postcode.")]
        [PostCode(ErrorMessage = "Please enter a valid UK Postcode.")]
        public string ApplicantPostcode { get; set; }

        public string ApplicantFullAddress { get; set; }

        [Display(Name = "Telephone")]
        [RequiredGroup("ApplicantTelephone", "ApplicantMobile", "ApplicantEmail")]
        [Telephone(ErrorMessage = "Please enter a valid telephone number.")]
        public string ApplicantTelephone { get; set; }

        [Display(Name = "Mobile")]
        [RequiredGroup("ApplicantTelephone", "ApplicantMobile", "ApplicantEmail")]
        [Telephone(ErrorMessage = "Please enter a valid mobile number.")]
        public string ApplicantMobile { get; set; }

        [Display(Name = "Email")]
        [RequiredGroup("ApplicantTelephone", "ApplicantMobile", "ApplicantEmail")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string ApplicantEmail { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please select the existing address.")]
        public long ExistingPropertyUrn { get; set; }

        [Display(Name = "1st Choice")]
        [Required(ErrorMessage = "Please enter your preferred address.")]
        public string ProposedAddress1 { get; set; }

        [Display(Name = "2nd Choice")]
        public string ProposedAddress2 { get; set; }

        [Display(Name = "3rd Choice")]
        public string ProposedAddress3 { get; set; }

        [Display(Name = "Effective Date")]
        public DateTime? EffectiveDate { get; set; }

        public bool IsRegisteredOwner { get; set; }

        [Display(Name="Additional Information")]
        public string AdditionalInformation { get; set; }

        [Display(Name = "Attachments")]
        // TODO: RequiredCollection not ever being reached
        [RequiredCollection(ErrorMessage = "You must attached at least one file.")]
        public ICollection<IFormFile> Attachments { get; set; }

        [Display(Name = "Signed")]
        [Required(ErrorMessage = "You must digitally sign the form.")]
        public string Signed { get; set; }

        [Display(Name = "Date")]
        public string SignedDate { get; set; }

        public string AddressLookupEndpoint { get; set; }

        public int AddressLookupPageSize { get; set; }

        public int AddressLookupMinChars { get; set; }

        public IEnumerable<SelectListItem> ApplicantTitleListItems { get; set; }
    }
}