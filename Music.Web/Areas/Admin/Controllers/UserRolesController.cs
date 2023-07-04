using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Music.Data;
using Music.Repository.ApplicationContext;
using Music.Web.UnitOfWork;

namespace Music.Web.Areas.Admin.Controllers
{
    public class UserRolesController : AdminBaseController
    {

        private IUnitOfWork unitOfWork;
        public UserRolesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public ActionResult Index()
        {
            // ToDo : Use UnitOfWork
            using (Context db = new Context())
            {
                var userRoles = db.UserRoles.Include(u => u.Role).Include(u => u.User);

                return View(userRoles.ToList());
            }      
        }



        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(unitOfWork.RoleService.GetAll(), "Id", "Title");
            ViewBag.UserId = new SelectList(unitOfWork.UserService.GetAll(), "Id", "UserName");
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,RoleId")] UserRole userRole)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.UserRolesService.Add(userRole);
                unitOfWork.save();
                return RedirectToAction("Index");
            }
            return View(userRole);
        }




        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRole userRole = unitOfWork.UserRolesService.Find(id.Value);
            if (userRole == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(unitOfWork.RoleService.GetAll(), "Id", "Title", userRole.RoleId);
            ViewBag.UserId = new SelectList(unitOfWork.UserService.GetAll(), "Id", "UserName", userRole.UserId);
            return View(userRole);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,RoleId")] UserRole userRole)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.UserRolesService.Update(userRole);
                unitOfWork.save();
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(unitOfWork.RoleService.GetAll(), "Id", "Title", userRole.RoleId);
            ViewBag.UserId = new SelectList(unitOfWork.UserService.GetAll(), "Id", "UserName", userRole.UserId);
            return View(userRole);
        }



        public ActionResult Delete(int id)
        {
            UserRole userRole = unitOfWork.UserRolesService.Find(id);
            unitOfWork.UserRolesService.Delete(userRole);
            unitOfWork.save();

            return RedirectToAction("Index");
        }

    }
}
