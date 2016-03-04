using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreetNaming.Web.Configuration
{
    public class StreetNamingOptions
    {
        public PaymentOptions Payment { get; set; }

        public class PaymentOptions
        {
            public string Provider { get; set; }

            public decimal Amount { get; set; }

            public char Currency { get; set; }

            public string Endpoint { get; set; }

            public string ApplicationId { get; set; }

            public string PaymentSourceCode { get; set; }

            public string Reference { get; set; }

            public string FundCode { get; set; }

            public string VatCode { get; set; }

            public string Narrative { get; set; }
        }
    }
}
