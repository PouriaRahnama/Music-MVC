using Music.Data;
using Music.Web.UnitOfWork;
using Music.Web.Utilities.ImageTools;
using System.Web;
using System.Web.Mvc;

namespace Music.Web.Areas.Admin.Controllers
{
   
    public class SingerController : AdminBaseController
    {
        private readonly IUnitOfWork unitOfWork;
        public SingerController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public ActionResult Index()
        {
            return View(unitOfWork.SingerService.GetAllSingers());

        }


        public ActionResult Create()
        {
            return View();
        }



        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(Singer newSinger, HttpPostedFileBase singerImage)
        {
            if (ModelState.IsValid)
            {
                if (singerImage != null)
                {
                    singerImage.AddImageToServer(singerImage.FileName, ImagePath.SingerOriginalServerPath, 100, 100, ImagePath.SingerThumbServerPath);
                    newSinger.SingerImage = singerImage.FileName;
                    unitOfWork.SingerService.AddSinger(newSinger);
                    unitOfWork.save();
                    return RedirectToAction("Index");
                }

                TempData["ErrorMessage"] = "لطفا تصویر را وارد کنید";
            }

            return View(newSinger);
        }


        public ActionResult Edit(int id)
        {
            var singer = unitOfWork.SingerService.GetSingerById(id);

            if (singer == null) return HttpNotFound();

            return View(singer);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Singer editedSinger, HttpPostedFileBase singerImage)
        {
            if (ModelState.IsValid)
            {
                if (singerImage != null)
                {
                    var imageName = editedSinger.Id + "_" + singerImage.FileName;
                    singerImage.AddImageToServer(imageName, ImagePath.SingerOriginalServerPath, 100, 100, ImagePath.SingerThumbServerPath, editedSinger.SingerImage);
                    editedSinger.SingerImage = imageName;
                }

                unitOfWork.SingerService.EditSinger(editedSinger);
                unitOfWork.save();
                return RedirectToAction("Index");
            }

            return View(editedSinger);
        }

        public ActionResult Delete(int id)
        {
            var singer = unitOfWork.SingerService.GetSingerById(id);

            if (singer != null)
            {
                singer.IsDelete = true;
                unitOfWork.SingerService.EditSinger(singer);
                unitOfWork.save();
                return Json(new { status = "Done" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { status = "NotFound" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Return(int id)
        {
            var singer = unitOfWork.SingerService.GetSingerById(id);

            if (singer != null)
            {
                singer.IsDelete = false;
                unitOfWork.SingerService.EditSinger(singer);
                unitOfWork.save();
                return Json(new { status = "Done" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { status = "NotFound" }, JsonRequestBehavior.AllowGet);
        }

    }
}