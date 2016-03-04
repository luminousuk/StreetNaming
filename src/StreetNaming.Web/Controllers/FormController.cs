using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Mvc;
using Microsoft.Net.Http.Headers;
using StreetNaming.Domain.Models;
using StreetNaming.Web.Models;
using StreetNaming.Web.ViewModels;

namespace StreetNaming.Web.Controllers
{
    public class FormController : Controller
    {
        private readonly StreetNamingEntities _db;
        private readonly IMapper _mapper;

        public FormController(StreetNamingEntities context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }

        public IActionResult ExistingProperty()
        {
            var viewModel = new ExistingPropertyViewModel
            {
                SignedDate = DateTime.Today.ToString("D")
            };
            return View(viewModel);
        }

        public IActionResult NewProperty()
        {
            var viewModel = new ExistingPropertyViewModel
            {
                SignedDate = DateTime.Today.ToString("D")
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ExistingProperty(ExistingPropertyViewModel viewModel)
        {
            var applicant = _mapper.Map<Applicant>(viewModel);

            // TODO: Determine if Applicant already exists
            _db.Applicants.Add(applicant);

            var request = _mapper.Map<Request>(viewModel);
            request.Applicant = applicant;
            request.RequestStatus = RequestStatus.New;
            _db.Requests.Add(request);

            await _db.SaveChangesAsync();

            return RedirectToAction("Initiate", "Payment", new { requestId = request.RequestId });
        }

        [HttpPost]
        public async Task<IActionResult> NewProperty(NewPropertyViewModel viewModel)
        {
            var applicant = _mapper.Map<Applicant>(viewModel);

            // TODO: Determine if Applicant already exists
            _db.Applicants.Add(applicant);

            var request = _mapper.Map<Request>(viewModel);
            request.Applicant = applicant;
            request.RequestStatus = RequestStatus.New;
            _db.Requests.Add(request);

            await _db.SaveChangesAsync();

            return RedirectToAction("Initiate", "Payment", new { requestId = request.RequestId });
        }
    }
}