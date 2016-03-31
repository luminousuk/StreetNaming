using Microsoft.AspNet.Mvc;
using StreetNaming.DAL;

namespace StreetNaming.Admin.Controllers
{
    public class GraphDataController : Controller
    {
        private readonly IStreetNamingRepository _repo;

        public GraphDataController(IStreetNamingRepository repo)
        {
            _repo = repo;
        }

        public IActionResult CasesPerMonth()
        {
            var data = _repo.GetMonthlyCaseCount();

            return Json(data);
        }

        public IActionResult MonthlyCashflow()
        {
            var data = _repo.GetMonthlyCashflow();

            return Json(data);
        }
    }
}