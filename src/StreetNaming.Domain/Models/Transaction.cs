using System;
using StreetNaming.Domain.Models.Interfaces;

namespace StreetNaming.Domain.Models
{
    public class Transaction
        : ICreatable
            , IReferable
    {
        // WORK IN PROGRESS

        public long TransactionId { get; set; }

        public long CaseId { get; set; }

        public Case Case { get; set; }

        public string Provider { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public int? ResponseCode { get; set; }

        public string ResponseDescription { get; set; }

        public DateTime? ResponseDate { get; set; }

        public TransactionStatus TransactionStatus { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid Reference { get; set; }
    }

    public enum TransactionStatus
    {
        Pending = 1 << 0,
        Complete = 1 << 1,
        Failed = 1 << 2,
        Cancelled = 1 << 3,
        Refunded = 1 << 4
    }
}