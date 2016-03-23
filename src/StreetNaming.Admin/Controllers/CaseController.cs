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
    public class CaseController : Controller
    {
        private readonly IStreetNamingRepository _repo;
        private readonly IMapper _mapper;

        public CaseController(IStreetNamingRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public IActionResult All()
        {
            var viewModel = new CaseIndexViewModel
            {
                Cases = _mapper.Map<ICollection<CaseIndexCaseViewModel>>(_repo.GetAllCases())
            };
            return View(viewModel);
        }
        public IActionResult Active()
        {
            var viewModel = new CaseIndexViewModel
            {
                Cases = _mapper.Map<ICollection<CaseIndexCaseViewModel>>(_repo.GetAllCases())
            };
            return View(viewModel);
        }

        public IActionResult Completed()
        {
            var viewModel = new CaseIndexViewModel
            {
                Cases = _mapper.Map<ICollection<CaseIndexCaseViewModel>>(_repo.GetAllCases())
            };
            return View(viewModel);
        }
    }
}
