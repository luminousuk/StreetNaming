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
    public class ApplicantController : Controller
    {
        private readonly IStreetNamingRepository _repo;
        private readonly IMapper _mapper;

        public ApplicantController(IStreetNamingRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [Route("")]
        public IActionResult List()
        {
            var viewModel = new ApplicantListViewModel
            {
                Applicants = _mapper.Map<ICollection<ApplicantListApplicantViewModel>>(_repo.GetAllApplicants())
            };

            ViewData["Title"] = "All Applicants";

            return View(viewModel);
        }
    }
}
