using System;

namespace StreetNaming.Admin.ViewModels
{
    public class CaseIndexCaseViewModel
    {
        public int CaseId { get; set; }

        public string CustomerReference { get; set; }

        public string CaseType { get; set; }

        public string CaseStatus { get; set; }

        public string ApplicantFullName { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}