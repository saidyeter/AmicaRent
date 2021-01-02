using System.Linq;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : RootController
    { 
        
        public ActionResult Index()
        {
            return View();
        } 
    }
}