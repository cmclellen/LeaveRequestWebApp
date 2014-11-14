using System;
using System.Linq;
using System.Web.Mvc;

using CompanyABC.Core.Config;
using CompanyABC.WebClient.Models;

using Utils;

namespace CompanyABC.WebClient.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IApplicationSettings applicationSettings)
        {
            Guard.NotNull(() => applicationSettings, applicationSettings);
            ApplicationSettings = applicationSettings;
        }

        private IApplicationSettings ApplicationSettings { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult JsConstants()
        {
            return PartialView(new JsConstantsViewModel
            {
                ApplicationSettings = ApplicationSettings
            });
        }
    }
}