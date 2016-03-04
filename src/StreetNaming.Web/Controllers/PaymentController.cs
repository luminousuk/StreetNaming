using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Routing;
using Microsoft.Data.Entity;
using Microsoft.Extensions.OptionsModel;
using StreetNaming.Domain.Models;
using StreetNaming.Web.Configuration;
using StreetNaming.Web.Models;
using StreetNaming.Web.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace StreetNaming.Web.Controllers
{
    public class PaymentController : Controller
    {
        private readonly StreetNamingEntities _context;
        private readonly IOptions<StreetNamingOptions> _options;

        public PaymentController(StreetNamingEntities context, IOptions<StreetNamingOptions> options)
        {
            _context = context;
            _options = options;
        }

        public async Task<IActionResult> Initiate(long requestId)
        {
            // TODO: Switch requestId to a GUID reference

            var request = await _context.Requests.FirstOrDefaultAsync(r => r.RequestId == requestId);

            if (request == null) return new BadRequestResult();

            // Some business logic here?

            var transaction = new Transaction
            {
                Request = request,
                Provider = _options.Value.Payment.Provider,
                Reference = Guid.NewGuid(),
                TransactionStatus = TransactionStatus.Pending,
                Amount = _options.Value.Payment.Amount,
                Currency = _options.Value.Payment.Currency
            };

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            var viewModel = new PaymentInitiateViewModel
            {
                BackButtonUrl = Url.Action("Initiate", "Payment", new {requestId = requestId}, "http"),
                CallingApplicationId = _options.Value.Payment.ApplicationId,
                CallingApplicationTransactionReference = transaction.Reference.ToString(),
                EndpointUrl = _options.Value.Payment.Endpoint,
                PaymentSourceCode = _options.Value.Payment.PaymentSourceCode,
                PaymentTotal = _options.Value.Payment.Amount,
                Payment_1 = string.Concat(
                    _options.Value.Payment.Reference, '|',
                    _options.Value.Payment.FundCode, '|',
                    _options.Value.Payment.Amount, '|',
                    _options.Value.Payment.VatCode, '|',
                    _options.Value.Payment.Narrative),
                ReturnUrl = Url.Action("ProviderResponse", "Payment", null, "http")
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ProviderResponse(PaymentResponseViewModel viewModel)
        {
            var reference = new Guid(viewModel.CallingApplicationTransactionReference);
            var transaction = await _context.Transactions.FirstOrDefaultAsync(t => t.Reference == reference);

            if (transaction == null) return HttpBadRequest();

            return View();
        }
    }
}