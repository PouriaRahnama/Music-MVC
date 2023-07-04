using Music.Web.UnitOfWork;
using System.Web.Mvc;

namespace Music.Web.UI.Controllers
{
    public class ValidateController : Controller
    {
        private IUnitOfWork UnitOfWork;
        public ValidateController(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }



        public ActionResult IsExistUserByEmail(string Email)
        {
            return Json(!UnitOfWork.UserService.IsExistUserByEmail(Email), JsonRequestBehavior.AllowGet);
        }



        public ActionResult IsExistUseruserName(string userName)
        {
            return Json(!UnitOfWork.UserService.IsExistUserByUserName(userName), JsonRequestBehavior.AllowGet);
        }



    }
}