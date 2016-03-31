using System;

namespace StreetNaming.Admin.ViewModels
{
    public class TransactionListTransactionViewModel
    {
        public Guid Reference { get; set; }

        public string CaseCustomerReference { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public string TransactionStatus { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}