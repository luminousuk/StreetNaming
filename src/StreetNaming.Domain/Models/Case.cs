using System;
using System.Collections.Generic;
using StreetNaming.Domain.Models.Interfaces;

namespace StreetNaming.Domain.Models
{
    public class Case
        : ICreatable
            , IModifiable
            , IReferable
    {
        public long CaseId { get; set; }

        public CaseType CaseType { get; set; }

        public CaseStatus CaseStatus { get; set; }

        public long ApplicantId { get; set; }

        public Applicant Applicant { get; set; }

        public string ProposedAddress1 { get; set; }

        public string ProposedAddress2 { get; set; }

        public string ProposedAddress3 { get; set; }

        public long? ExistingPropertyUrn { get; set; }

        public bool IsRegisteredOwner { get; set; }

        public string Signed { get; set; }

        public ICollection<Attachment> Attachments { get; set; }

        public ICollection<Transaction> Transactions { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public Guid Reference { get; set; }
    }

    public enum CaseType
    {
        NewPropertyCase = 1<<0,
        ExistingPropertyCase = 1<<1
    }

    public enum CaseStatus
    {
        New = 0,
        Active = 1<<0,
        Completed = 1<<1,
        Rejected = 1<<2,
        Cancelled = 1<<3,
        Refunded = 1<<4
    }
}