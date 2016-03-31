using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNet.Mvc;
using StreetNaming.Admin.ViewModels;
using StreetNaming.DAL;

namespace StreetNaming.Admin.Controllers
{
    [Route("[controller]s")]
    public class ApplicantController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IStreetNamingRepository _repo;

        public ApplicantController(IStreetNamingRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [Route("")]
        public IActionResult All()
        {
            var viewModel = new ApplicantListViewModel
            {
                Applicants = _mapper.Map<ICollection<ApplicantListApplicantViewModel>>(_repo.GetAllApplicants())
            };

            ViewData["Title"] = "All Applicants";

            return View("List", viewModel);
        }
    }
}