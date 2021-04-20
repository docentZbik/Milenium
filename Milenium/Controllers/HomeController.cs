using Milenium.Models;
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
    }
}