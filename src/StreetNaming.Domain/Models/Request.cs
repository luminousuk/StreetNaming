using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreetNaming.Domain.Models
{
    public class Request
    {
        public long RequestId { get; set; }

        public RequestType RequestType { get; set; }

        public Applicant Applicant { get; set; }

        public string ProposedAddress1 { get; set; }

        public string ProposedAddress2 { get; set; }

        public string ProposedAddress3 { get; set; }

        public string ExistingAddress { get; set; }

        public bool IsRegisteredOwner { get; set; }

        public string Signed { get; set; }

        public DateTime SubmitDate { get; set; }
    }

    public enum RequestType
    {
        NewPropertyRequest = 1,
        ExistingPropertyRequest = 2
    }
}
