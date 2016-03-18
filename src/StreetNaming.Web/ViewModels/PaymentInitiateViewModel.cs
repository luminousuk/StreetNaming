using StreetNaming.Domain.Models;

namespace StreetNaming.Web.ViewModels
{
    public class PaymentInitiateViewModel
    {
        public string EndpointUrl { get; set; }

        public string CallingApplicationId { get; set; }

        public decimal PaymentTotal { get; set; }

        public string ReturnUrl { get; set; }

        public string BackButtonUrl { get; set; }

        public string PaymentSourceCode { get; set; }

        // ReSharper disable once InconsistentNaming
        public string Payment_1 { get; set; }

        public string CallingApplicationTransactionReference { get; set; }

        public CaseType CaseType { get; set; }

        public string CaseReference { get; set; }
    }
}