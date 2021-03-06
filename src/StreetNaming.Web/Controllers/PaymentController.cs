﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
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

        public async Task<IActionResult> Initiate(string caseReference)
        {
            var request =
                await
                    _context.Cases.Include(r => r.Applicant)
                        .FirstOrDefaultAsync(r => r.CustomerReference == caseReference);

            if (request == null) return new BadRequestResult();

            if (!request.IsRegisteredOwner) return RedirectToAction("NoPayment", new {caseReference});

            // Some business logic here?

            // Get existing pending transaction for this request (if exists)
            var transaction =
                await
                    _context.Transactions.FirstOrDefaultAsync(
                        t => t.CaseId == request.CaseId && t.TransactionStatus == TransactionStatus.Pending);

            if (transaction == null)
            {
                transaction = new Transaction
                {
                    Case = request,
                    Provider = _options.Value.Payment.Provider,
                    Reference = Guid.NewGuid(),
                    TransactionStatus = TransactionStatus.Pending,
                    Currency = _options.Value.Payment.Currency
                };

                switch (request.CaseType)
                {
                    case CaseType.NewPropertyCase:
                        transaction.Amount = _options.Value.Payment.NewPropertyAmount;
                        break;
                    case CaseType.ExistingPropertyCase:
                        transaction.Amount = _options.Value.Payment.ExistingPropertyAmount;
                        break;
                    default:
                        throw new InvalidOperationException("Invalid Case type.");
                }

                _context.Transactions.Add(transaction);
                await _context.SaveChangesAsync();
            }

            var viewModel = new PaymentInitiateViewModel
            {
                BackButtonUrl = Url.Action("Initiate", "Payment", new {caseReference}, "http"),
                CallingApplicationId = _options.Value.Payment.ApplicationId,
                CallingApplicationTransactionReference = transaction.Reference.ToString(),
                EndpointUrl = _options.Value.Payment.Endpoint,
                PaymentSourceCode = _options.Value.Payment.PaymentSourceCode,
                PaymentTotal = transaction.Amount,
                Payment_1 =
                    string.Join("|", /* Reference */ _options.Value.Payment.AccountReference, /* Fund Code */
                        _options.Value.Payment.FundCode, /* Amount */ transaction.Amount, /* Vat Code */
                        _options.Value.Payment.VatCode, /* Narrative */ _options.Value.Payment.Narrative,
                        /* Business Name */ "", /* Premise Number */ request.Applicant.HouseNumber?.ToString(),
                        /* Premise Name */ request.Applicant.HouseName, /* Street */ request.Applicant.Street,
                        /* Area */ "", /* Town */ request.Applicant.Town, /* County */ request.Applicant.County,
                        /* Post Code */ request.Applicant.PostCode?.ToUpper(), /* Alternative Account Reference */ "",
                        /* Line Based Refund Receipt Number */ ""),
                ReturnUrl = Url.Action("ProviderResponse", "Payment", null, "http"),
                CaseType = request.CaseType,
                CaseReference = request.CustomerReference
            };

            return View(viewModel);
        }

        public async Task<IActionResult> ProviderResponse(PaymentResponseViewModel viewModel)
        {
            var reference = new Guid(viewModel.CallingApplicationTransactionReference);

            var transaction = await _context.Transactions.FirstOrDefaultAsync(t => t.Reference == reference);

            if (transaction == null) return HttpBadRequest();

            transaction.ResponseDate = DateTime.Now;
            transaction.ResponseCode = int.Parse(viewModel.ResponseCode);
            transaction.TransactionStatus = transaction.ResponseCode == 0
                ? TransactionStatus.Complete
                : TransactionStatus.Failed;
            transaction.ResponseDescription = viewModel.ResponseDescription;

            // Business Logic here

            await _context.SaveChangesAsync();

            return RedirectToAction("Completed", new {transactionReference = transaction.Reference});
        }

        public async Task<IActionResult> Completed(Guid transactionReference)
        {
            var transaction = await _context.Transactions.FirstOrDefaultAsync(t => t.Reference == transactionReference);

            if (transaction == null) return HttpBadRequest();

            if (transaction.ResponseCode > 0)
                return View("Failed", transaction);

            var cas = await _context.Cases.FirstOrDefaultAsync(c => c.CaseId == transaction.CaseId);
            cas.CaseStatus = CaseStatus.Active;
            await _context.SaveChangesAsync();

            return View("Completed", transaction);
        }

        public async Task<IActionResult> NoPayment(string caseReference)
        {
            var request =
                await
                    _context.Cases.Include(r => r.Applicant)
                        .FirstOrDefaultAsync(r => r.CustomerReference == caseReference);

            if (request == null) return new BadRequestResult();

            if (request.IsRegisteredOwner) return RedirectToAction("Initiate", new { caseReference });

            var viewModel = new PaymentNoPaymentViewModel
            {
                CaseType = request.CaseType,
                CaseReference = request.CustomerReference
            };

            return View(viewModel);
        }
    }
}