using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreetNaming.Admin.ViewModels
{
    public class TransactionListViewModel
    {
        public ICollection<TransactionListTransactionViewModel> Transactions { get; set; }
    }
}
