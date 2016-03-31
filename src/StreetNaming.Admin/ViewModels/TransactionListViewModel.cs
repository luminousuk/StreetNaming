using System.Collections.Generic;

namespace StreetNaming.Admin.ViewModels
{
    public class TransactionListViewModel
    {
        public ICollection<TransactionListTransactionViewModel> Transactions { get; set; }
    }
}