using System.Web.Mvc;

namespace prjEBDSystem.Controllers
{
    public class SiteController : Controller
    {
        // GET: Site
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
    }
}