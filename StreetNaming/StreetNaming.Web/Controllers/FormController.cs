using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using StreetNaming.Web.ViewModels;

namespace StreetNaming.Web.Controllers
{
    public class FormController : Controller
    {
        public FormController()
        {
            
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
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> NewProperty(NewPropertyViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
