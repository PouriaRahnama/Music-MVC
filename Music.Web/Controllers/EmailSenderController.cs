using System.Web.Mvc;

namespace Music.Web.UI.Controllers
{
    public class EmailSenderController : Controller
    {
        
        public ActionResult ActivateEmail()
        {
            return PartialView();
        }
    }
}