using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using StreetNaming.Domain;
using StreetNaming.Domain.Models;
using StreetNaming.Web.ViewModels;

namespace StreetNaming.Web.Controllers
{
    public class FormController : Controller
    {
        private readonly IStreetNamingRepositoryAsync _repository;

        public FormController(IStreetNamingRepositoryAsync repository)
        {
            _repository = repository;
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
            await _repository.Add(applicant);

            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> NewProperty(NewPropertyViewModel viewModel)
        {
            // TODO: AutoMapper map viewModel into domain models
            var applicant = new Applicant();
            await _repository.Add(applicant);

            throw new NotImplementedException();
        }
    }
}
