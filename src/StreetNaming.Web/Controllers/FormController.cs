using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Mvc;
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
            return View();
        }

        public IActionResult NewProperty()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ExistingProperty(ExistingPropertyViewModel viewModel)
        {
            var applicant = _mapper.Map<Applicant>(viewModel);

            _db.Applicants.Add(applicant);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> NewProperty(NewPropertyViewModel viewModel)
        {
            var applicant = _mapper.Map<Applicant>(viewModel);

            _db.Applicants.Add(applicant);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}