using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmicaRent.OfficialWeb.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return RedirectToAction("Anasayfa");
        }

        [Route("anasayfa")]
        public ActionResult Anasayfa()
        {
            return View();
        }

        [Route("hakkinda")]
        public ActionResult Hakkinda()
        {
            return View();
        }

        [Route("iletisim")]
        public ActionResult Iletisim()
        {
            return View();
        }

        [Route("araclistesi")]
        public ActionResult AracListesi()
        {
            return View();
        }
    }
}