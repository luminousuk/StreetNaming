using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using StreetNaming.Admin.ViewModels;
using StreetNaming.DAL;
using StreetNaming.Domain.Models;

namespace StreetNaming.Admin.Controllers
{
    [Route("[Controller]")]
    public class CaseController : Controller
    {
        private readonly IStreetNamingRepository _repo;
        private readonly IMapper _mapper;

        public CaseController(IStreetNamingRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [Route("All")]
        public IActionResult All()
        {
            var viewModel = new CaseIndexViewModel
            {
                Cases = _mapper.Map<ICollection<CaseIndexCaseViewModel>>(_repo.GetAllCases())
            };

            ViewData["Title"] = "All Cases";

            return View("List", viewModel);
        }
        [Route("Active")]
        public IActionResult Active()
        {
            var viewModel = new CaseIndexViewModel
            {
                Cases = _mapper.Map<ICollection<CaseIndexCaseViewModel>>(_repo.GetActiveCases())
            };

            ViewData["Title"] = "Active Cases";

            return View("List", viewModel);
        }

        [Route("Completed")]
        public IActionResult Completed()
        {
            var viewModel = new CaseIndexViewModel
            {
                Cases = _mapper.Map<ICollection<CaseIndexCaseViewModel>>(_repo.GetCompletedCases())
            };

            ViewData["Title"] = "Completed Cases";

            return View("List", viewModel);
        }

        [Route("{reference}")]
        public IActionResult Get(string reference)
        {
            var c = _repo.GetCase(reference);

            if (c == null)
                return new HttpNotFoundResult();

            var viewModel = _mapper.Map<CaseGetViewModel>(c);

            ViewData["Title"] = viewModel.CustomerReference;
            viewModel.Statuses = Enum.GetValues(typeof (CaseStatus)).Cast<CaseStatus>().Select(cs => new SelectListItem { Text = cs.ToString(), Value = cs.ToString() });

            return View(viewModel);
        }

        [Route("{reference}/{filename}")]
        public IActionResult Attachment(string reference, string filename)
        {
            try
            {
                var attachment = _repo.GetAttachment(reference, filename);

                return File(attachment.Bytes, attachment.ContentType, attachment.OriginalFileName);
            }
            catch (Exception)
            {
                return new HttpNotFoundResult();
            }
        }

        [Route("{reference}/Status")]
        public IActionResult UpdateStatus(string reference, string caseStatus)
        {
            try
            {
                var status = (CaseStatus) Enum.Parse(typeof (CaseStatus), caseStatus);

                _repo.UpdateCaseStatus(reference, status);
            }
            catch (ArgumentException)
            {
                return new HttpNotFoundResult();
            }

            return RedirectToAction("Get", new { reference });
        }
    }
}
