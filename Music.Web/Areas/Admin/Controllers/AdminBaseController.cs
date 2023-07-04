using System.Web.Mvc;

namespace Music.Web.Areas.Admin.Controllers
{

    [Authorize(Roles = "Admin")]
    public class AdminBaseController : Controller
    {


    }

}