namespace StreetNaming.Web.Configuration
{
    public class StreetNamingOptions
    {
        public PaymentOptions Payment { get; set; }

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
    }
}