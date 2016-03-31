using System;

namespace StreetNaming.Admin.ViewModels
{
    public class CaseListCaseViewModel
    {
        public int CaseId { get; set; }

        public string CustomerReference { get; set; }

        public string CaseType { get; set; }

        public string CaseStatus { get; set; }

        public string ApplicantFullName { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CaseStatusFormat
        {
            get
            {
                switch (CaseStatus)
                {
                    case "New":
                        return $"<span class=\"text-warning\">{CaseStatus}</span>";
                    case "Active":
                        return $"<span class=\"text-warning\">{CaseStatus}</span>";
                    case "Completed":
                        return $"<span class=\"text-success\">{CaseStatus}</span>";
                    case "Rejected":
                        return $"<span class=\"text-danger\">{CaseStatus}</span>";
                    case "Cancelled":
                        return $"<span class=\"text-danger\">{CaseStatus}</span>";
                    case "Refunded":
                        return $"<span class=\"text-danger\">{CaseStatus}</span>";
                    default:
                        return null;
                }
            }
        }
    }
}