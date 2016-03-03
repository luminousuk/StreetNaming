using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Microsoft.Extensions.OptionsModel;
using StreetNaming.Domain.Models;
using StreetNaming.Web.Configuration;
using StreetNaming.Web.Models;

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

            // TODO: Create viewmodel and auto-post form to civica url
            return View();
        }
    }
}