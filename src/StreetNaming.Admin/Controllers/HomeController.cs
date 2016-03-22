using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using StreetNaming.Admin.ViewModels;
using StreetNaming.DAL;

namespace StreetNaming.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStreetNamingRepository _repo;

        public HomeController(IStreetNamingRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var viewModel = new HomeDashboardViewModel
            {
                ActiveCaseCount = _repo.GetActiveCaseCount(),
                ApplicantCount = _repo.GetApplicantCount(),
                CaseFollowUpCount = _repo.GetCaseFollowUpCount(),
                UnpaidTransactionCount = _repo.GetUnpaidTransactionCount()
            };

            return View(viewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
