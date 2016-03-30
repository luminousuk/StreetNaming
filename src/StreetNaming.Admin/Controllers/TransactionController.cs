using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Mvc;
using StreetNaming.Admin.ViewModels;
using StreetNaming.DAL;

namespace StreetNaming.Admin.Controllers
{
    [Route("[controller]s")]
    public class TransactionController : Controller
    {
        private readonly IStreetNamingRepository _repo;
        private readonly IMapper _mapper;

        public TransactionController(IStreetNamingRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [Route("")]
        public IActionResult All()
        {
            var viewModel = new TransactionListViewModel
            {
                Transactions = _mapper.Map<ICollection<TransactionListTransactionViewModel>>(_repo.GetAllTransactions())
            };

            ViewData["Title"] = "All Transactions";

            return View("List", viewModel);
        }

        [Route("Pending")]
        public IActionResult Pending()
        {
            var viewModel = new TransactionListViewModel
            {
                Transactions = _mapper.Map<ICollection<TransactionListTransactionViewModel>>(_repo.GetPendingTransactions())
            };

            ViewData["Title"] = "Pending Transactions";

            return View("List", viewModel);
        }

        [Route("{reference}")]
        public IActionResult Get(Guid reference)
        {
            return Content(reference.ToString());
        }
    }
}
