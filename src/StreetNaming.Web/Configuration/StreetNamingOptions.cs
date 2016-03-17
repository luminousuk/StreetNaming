using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;

namespace StreetNaming.Web.Configuration
{
    public class StreetNamingOptions
    {
        public PaymentOptions Payment { get; set; }

        public AddressLookupOptions AddressLookup { get; set; }

        public string NewPropertyReferencePrefix { get; set; }

        public string ExistingPropertyReferencePrefix { get; set; }

        public IEnumerable<string> ApplicantTitles => ApplicantTitlesString?.Split(',');

        public string ApplicantTitlesString { get; set; }

        public class PaymentOptions
        {
            public string Provider { get; set; }

            public decimal Amount { get; set; }

            public string Currency { get; set; }

            public string Endpoint { get; set; }

            public string ApplicationId { get; set; }

            public string PaymentSourceCode { get; set; }

            public string AccountReference { get; set; }

            public string FundCode { get; set; }

            public string VatCode { get; set; }

            public string Narrative { get; set; }
        }

        public class AddressLookupOptions
        {
            public string Endpoint { get; set; }

            public int PageSize { get; set; }

            public int MinChars { get; set; }
        }
    }
}