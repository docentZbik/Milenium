using Milenium.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Milenium.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new UserData());
        }

        [HttpGet]
        public ActionResult SwitchLanguage(bool isLanguageChanged = false)
        {
            string cultureType = string.Empty;
            if (isLanguageChanged)
            {
                cultureType = "en-GB";
            }
            else
            {
                cultureType = "pl-PL";
            }

            var targetCultureInfo = new CultureInfo(cultureType);
            CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureType);
            CultureInfo.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureType);
            CultureInfo.DefaultThreadCurrentCulture = targetCultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = targetCultureInfo;

            return View("Index", new UserData { IsLanguageChanged = isLanguageChanged });
        }

        [HttpPost]
        public ActionResult SubmitUserData(UserData userData)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Summary",userData);
            }

            return View("Index",userData);
        }

        [HttpGet]
        public ActionResult Summary(UserData userData)
        {
            return View("Summary",userData);
        }
    }
}