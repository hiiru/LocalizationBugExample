using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace LocalizationExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> _localizer;

        public HomeController(IStringLocalizer<HomeController> localizer)
        {
            _localizer = localizer;
        }

        public IActionResult Index(bool curly = false)
        {
            var model = new ExampleModel
            {
                Argument = "Argument"
            };
            model.StringLocalizedNoArguments = _localizer["NoArguments"];
            model.StringLocalizedWithArguments = _localizer["WithArguments", model.Argument];
            model.StringLocalizedNoArgumentsCurly = _localizer["NoArgumentsJson"];
            model.Curly = curly;
            return View(model);
        }
    }
}
