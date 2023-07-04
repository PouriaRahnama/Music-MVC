using System.Web.Mvc;

namespace Music.Web.Areas.Admin.Controllers
{
   
    public class HomeController : AdminBaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}