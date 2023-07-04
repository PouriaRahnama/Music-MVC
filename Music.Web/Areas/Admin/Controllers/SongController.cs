using Music.Data;
using Music.Web.UnitOfWork;
using Music.Web.Utilities.FileTools;
using Music.Web.Utilities.Generators;
using Music.Web.Utilities.ImageTools;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Music.Web.Areas.Admin.Controllers
{
   
    public class SongController : AdminBaseController
    {
        private readonly IUnitOfWork unitOfWork;
        public SongController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public ActionResult Index(int id)
        {
            var singer = unitOfWork.SingerService.GetSingerById(id);

            if (singer == null) return HttpNotFound();

            var songs = unitOfWork.SongService.GetAllSingerSongs(id);

            ViewBag.SingerId = id;

            return View(songs);
        }



        public ActionResult Create(int id)
        {
            var singer = unitOfWork.SingerService.GetSingerById(id);

            if (singer == null) return HttpNotFound();

            return View(new Song { SingerId = id });
        }



        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(Song newSong, HttpPostedFileBase songFile, HttpPostedFileBase songImage)
        {
            if (ModelState.IsValid)
            {
                if (songFile != null)
                {
                    string fileName = StringGenerator.GenerateGuidName() + Path.GetExtension(songFile.FileName);
                    string imageName = newSong.SongName + Path.GetExtension(songImage.FileName);
                    songImage.AddImageToServer(imageName, ImagePath.SongOriginalServerPath, 100, 100, ImagePath.SongThumbServerPath);
                    songFile.AddFileToServer(FilePath.SongServerPath, fileName);
                    newSong.SongFileName = fileName;
                    newSong.SongImageName = imageName;
                    newSong.CreateDate = DateTime.Now;
                    unitOfWork.SongService.AddSong(newSong);
                    unitOfWork.save();
                    return RedirectToAction("Index", new { id = newSong.SingerId });
                }

                TempData["ErrorMessage"] = "لطفا فایل را وارد کنید";
            }

            return View(newSong);
        }



        public ActionResult Edit(int id)
        {
            var song = unitOfWork.SongService.GetSongById(id);

            if (song == null) return HttpNotFound();

            return View(song);
        }



        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Song editedSong, HttpPostedFileBase songFile, HttpPostedFileBase songImage)
        {
            if (ModelState.IsValid)
            {
                if (songFile != null)
                {
                    string fileName = StringGenerator.GenerateGuidName() + Path.GetExtension(songFile.FileName);
                    songFile.AddFileToServer(FilePath.SongServerPath, fileName, editedSong.SongFileName);
                    editedSong.SongFileName = fileName;
                }
                if (songImage != null)
                {
                    string imageName = editedSong.SongName + Path.GetExtension(songImage.FileName);
                    songImage.AddImageToServer(imageName, ImagePath.SongOriginalServerPath, 100, 100, ImagePath.SongThumbServerPath, editedSong.SongImageName);
                    editedSong.SongImageName = imageName;
                }

                unitOfWork.SongService.EditSong(editedSong);
                unitOfWork.save();
                return RedirectToAction("Index", new { id = editedSong.SingerId });
            }

            return View(editedSong);
        }


        public ActionResult Delete(int id)
        {
            var song = unitOfWork.SongService.GetSongById(id);

            if (song != null)
            {
                song.IsDelete = true;
                unitOfWork.SongService.EditSong(song);
                unitOfWork.save();

                return Json(new { status = "Done" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { status = "NotFound" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Return(int id)
        {
            var song = unitOfWork.SongService.GetSongById(id);

            if (song != null)
            {
                song.IsDelete = false;
                unitOfWork.SongService.EditSong(song);
                unitOfWork.save();

                return Json(new { status = "Done" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { status = "NotFound" }, JsonRequestBehavior.AllowGet);
        }




    }
}