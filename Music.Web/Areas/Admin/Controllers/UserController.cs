using Music.Service.DTO_ViewModel_.User;
using Music.Web.UnitOfWork;
using System.Web.Mvc;

namespace Music.Web.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
       
        private IUnitOfWork unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

    
        public ActionResult Index(AdminUsersDto filter)
        {
            filter.TakeEntity = 10;
            var users = unitOfWork.UserService.GetUsersByFilter(filter);
            return View(users);
        }



        public ActionResult Edit(int id)
        {
            var user = unitOfWork.UserService.GetUserForEdit(id);
            
            if (user == null) return HttpNotFound();

            return View(user);
        }



        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(AdminEditUserDto editedUser)
        {
            // if (!unitOfWork.UserService.IsExistUserByUserName(editedUser.UserName, editedUser.CurrentUserName))
            if (!unitOfWork.UserService.IsExistUserByUserName(editedUser.UserName))
            {
                // if (!unitOfWork.UserService.IsExistUserByEmail(editedUser.Email, editedUser.CurrentEmail))
                if (!unitOfWork.UserService.IsExistUserByEmail(editedUser.Email))
                {
                    var user = unitOfWork.UserService.GetUserByUserId(editedUser.UserId);
                    user.IsActive = editedUser.IsActive;
                    user.UserName = editedUser.UserName;
                    user.Email = editedUser.Email;
                    unitOfWork.UserService.UpdateUser(user);
                    unitOfWork.save();
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("Email", "ایمیل استفاده شده تکراری میباشد");
            }
            else
            {
                ModelState.AddModelError("UserName", "نام کاربری استفاده شده تکراری میباشد");
            }

            return View(editedUser);
        }



        public ActionResult Delete(int Id)
        {
            var user = unitOfWork.UserService.GetUserByUserId(Id);

            if (user != null)
            {
                user.IsDelete = true;
                unitOfWork.UserService.UpdateUser(user);
                unitOfWork.save();

                return Json(new { status = "Done" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { status = "NotFound" }, JsonRequestBehavior.AllowGet);
        }



        public ActionResult Return(int Id)
        {
            var user = unitOfWork.UserService.GetUserByUserId(Id);

            if (user != null)
            {
                user.IsDelete = false;
                unitOfWork.UserService.UpdateUser(user);
                unitOfWork.save();

                return Json(new { status = "Done" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { status = "NotFound" }, JsonRequestBehavior.AllowGet);
        }


    }
}