using Music.Service.DTO_ViewModel_;
using Music.Web.UnitOfWork;
using Music.Web.Utilities.Tools;
using System.Web.Mvc;

namespace Music.Web.Controllers
{
    public class SongController : Controller
    {
        private readonly IUnitOfWork unitOfWork;


        public SongController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public ActionResult Index(AllSongsDTO filter)
        {
            filter.TakeEntity = 12;

            var songs = unitOfWork.SongService.GetAllSongs(filter);

            return View(songs);
        }



        [Route("SingleSong/{songId:Int}/{songName}", Name = "SingleSong")]
        public ActionResult SingleSong(int songId, string songName)
        {
            var song = unitOfWork.SongService.GetSingleSong(songId);

            if (song == null) return HttpNotFound();

            if (!unitOfWork.SongService.HasUserVisitedSong(songId, UserManager.GetUserIP()))
            {
                unitOfWork.SongService.AddVisitForSong(songId, UserManager.GetUserIP());
                unitOfWork.save();
            }

            return View(song);
        }



        public ActionResult LikeSong(int songId)
        {
            if (unitOfWork.SongService.IsExistSongById(songId))
            {
                if (unitOfWork.SongService.HasUserLikedSong(songId, UserManager.GetUserIP()))
                {
                    unitOfWork.SongService.DisLikeSong(songId, UserManager.GetUserIP());
                    unitOfWork.save();
                    return Json(new { status = "DisLike" }, JsonRequestBehavior.AllowGet);
                }

                unitOfWork.SongService.LikeSong(songId, UserManager.GetUserIP());
                unitOfWork.save();
                return Json(new { status = "Like" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { status = "NotFound" }, JsonRequestBehavior.AllowGet);
        }

    }
}