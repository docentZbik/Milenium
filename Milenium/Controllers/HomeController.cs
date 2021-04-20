﻿using Milenium.Models;
using System.Globalization;
using System.Web;
using System.Web.Mvc;

namespace Milenium.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SwitchLanguage()
        {
            return new EmptyResult();
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


        private bool ValidateCultureType(string cultureType)
        {
            try
            {
                CultureInfo.GetCultureInfo(cultureType);
                return true;
            }
            catch(CultureNotFoundException)
            {
                return false;
            }
        }

        private void ChangeCurrentCulutre(string cultureType)
        {
            var currentCulture = CultureInfo.CurrentCulture.Name;

            if(currentCulture != cultureType)
            {
                var targetCultureInfo = new CultureInfo(cultureType);
                CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureType);
                CultureInfo.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureType);
                CultureInfo.DefaultThreadCurrentCulture = targetCultureInfo;
                CultureInfo.DefaultThreadCurrentUICulture = targetCultureInfo;
            }
        }
    }
}