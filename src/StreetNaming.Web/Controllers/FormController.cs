using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using StreetNaming.Domain;
using StreetNaming.Domain.Models;
using StreetNaming.Web.Models;
using StreetNaming.Web.ViewModels;

namespace StreetNaming.Web.Controllers
{
    public class FormController : Controller
    {
        private readonly StreetNamingEntities _db;

        public FormController(StreetNamingEntities context)
        {
            _db = context;
        }

        public IActionResult ExistingProperty()
        {
            return View();
        }

        public IActionResult NewProperty()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ExistingProperty(ExistingPropertyViewModel viewModel)
        {
            // TODO: AutoMapper map viewModel into domain models
            var applicant = new Applicant();

            _db.Applicants.Add(applicant);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> NewProperty(NewPropertyViewModel viewModel)
        {
            // TODO: AutoMapper map viewModel into domain models
            var applicant = new Applicant();

            _db.Applicants.Add(applicant);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
