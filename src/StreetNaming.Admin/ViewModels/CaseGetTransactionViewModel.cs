using System;

namespace StreetNaming.Admin.ViewModels
{
    public class CaseGetTransactionViewModel
    {
        public Guid Reference { get; set; }

        public string Provider { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public int? ResponseCode { get; set; }

        public string ResponseDescription { get; set; }

        public string TransactionStatus { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}