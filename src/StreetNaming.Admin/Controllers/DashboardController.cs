using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using StreetNaming.Admin.ViewModels;
using StreetNaming.DAL;

namespace StreetNaming.Admin.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IStreetNamingRepository _repo;

        public DashboardController(IStreetNamingRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var viewModel = new DashboardIndexViewModel
            {
                ActiveCaseCount = _repo.GetActiveCaseCount(),
                ApplicantCount = _repo.GetApplicantCount(),
                CaseFollowUpCount = _repo.GetCaseFollowUpCount(),
                UnpaidTransactionCount = _repo.GetPendingTransactionCount()
            };

            return View(viewModel);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
