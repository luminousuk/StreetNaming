namespace StreetNaming.Web.ViewModels
{
    public class PaymentResponseViewModel
    {
        public string PaymentAuthorisationCode { get; set; }

        public string IncomeManagementReceiptNumber { get; set; }

        public string OriginatorsReference { get; set; }

        public string CallingApplicationTransactionReference { get; set; }

        public string CardScheme { get; set; }

        public string CardType { get; set; }

        public string CardValidationResults { get; set; }

        public string PaymentAmount { get; set; }

        public string Tendered { get; set; }

        public string Change { get; set; }

        public string Name { get; set; }

        public string ChequeNumber { get; set; }

        public string ResponseCode { get; set; }

        public string ResponseDescription { get; set; }
    }
}