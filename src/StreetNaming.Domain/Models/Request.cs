using System;
using System.Collections.Generic;
using StreetNaming.Domain.Models.Interfaces;

namespace StreetNaming.Domain.Models
{
    public class Request
        : ICreatable
            , IModifiable
    {
        public long RequestId { get; set; }

        public RequestType RequestType { get; set; }

        public RequestStatus RequestStatus { get; set; }

        public long ApplicantId { get; set; }

        public Applicant Applicant { get; set; }

        public string ProposedAddress1 { get; set; }

        public string ProposedAddress2 { get; set; }

        public string ProposedAddress3 { get; set; }

        public string ExistingAddress { get; set; }

        public bool IsRegisteredOwner { get; set; }

        public string Signed { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public ICollection<Attachment> Attachments { get; set; }
    }

    public enum RequestType
    {
        NewPropertyRequest = 0,
        ExistingPropertyRequest = 1
    }

    public enum RequestStatus
    {
        New = 0,
        Active = 1,
        Completed = 2,
        Rejected = 4
    }
}