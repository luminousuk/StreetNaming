using System.Collections.Generic;

namespace StreetNaming.Admin.ViewModels
{
    public class CaseFollowUpCaseViewModel : CaseListCaseViewModel
    {
        public CaseFollowUpCaseViewModel()
        {
            Reasons = new List<string>();
        }

        public ICollection<string> Reasons { get; set; }

        public bool IsRegisteredOwner { get; set; }

        public ICollection<CaseFollowUpCaseTransactionViewModel> Transactions { get; set; }
    }
}