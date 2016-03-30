using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Mvc.Rendering;

namespace StreetNaming.Admin.ViewModels
{
    public class CaseGetViewModel
    {
        public string CustomerReference { get; set; }

        [Display(Name = "Type")]
        public string CaseType { get; set; }

        [Display(Name = "Status")]
        public string CaseStatus { get; set; }

        [Display(Name = "Title")]
        public string ApplicantTitle { get; set; }

        [Display(Name = "Forename(s)")]
        public string ApplicantFirstName { get; set; }

        [Display(Name = "Surname")]
        public string ApplicantLastName { get; set; }

        public int? ApplicantHouseNumber { get; set; }

        public string ApplicantHouseName { get; set; }

        public string ApplicantStreet { get; set; }

        public string ApplicantTown { get; set; }

        public string ApplicantCounty { get; set; }

        public string ApplicantPostCode { get; set; }

        [Display(Name = "Address")]
        public string ApplicantFullAddress { get; set; }

        [Display(Name = "Telephone")]
        public string ApplicantTelephone { get; set; }

        [Display(Name = "Mobile")]
        public string ApplicantMobile { get; set; }

        [Display(Name = "Email")]
        public string ApplicantEmail { get; set; }

        public string ProposedAddress1 { get; set; }

        public string ProposedAddress2 { get; set; }

        public string ProposedAddress3 { get; set; }

        [Display(Name = "Effective Date")]
        public DateTime? EffectiveDate { get; set; }

        [Display(Name = "UPRN")]
        public long? ExistingPropertyUrn { get; set; }

        public bool IsRegisteredOwner { get; set; }

        public string Signed { get; set; }

        public ICollection<CaseGetAttachmentViewModel> Attachments { get; set; }

        public ICollection<CaseGetTransactionViewModel> Transactions { get; set; }

        [Display(Name = "Created")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Additional Information")]
        public string AdditionalInformation { get; set; }

        public IEnumerable<SelectListItem> Statuses { get; set; }
    }
}