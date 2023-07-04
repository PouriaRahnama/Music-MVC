using Music.Web.UnitOfWork;
using System.Linq;
using System.Web.Mvc;


namespace Music.Web.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


      
        public ActionResult Index()
        {         
            return View();
        }

        public ActionResult LatestSongsHeader()
        {
            return PartialView(unitOfWork.SongService.GetLatestSongsForHeader());
        }

        public ActionResult Favorites()
        {
            return PartialView(unitOfWork.SongService.GetFavoritesSongs());
        }

        public ActionResult FooterSlider()
        {
            return PartialView("_FooterSlider", unitOfWork.SongService.GetSongsOrderedByVisit());
        }

        public ActionResult SiteSlider()
        {           
            return PartialView(unitOfWork.SliderService.GetActivatedSliders());
        }

        public ActionResult Search(string search)
        {
            var result = unitOfWork.SongService.GetBySearch(search);
            ViewBag.search = search;
            return View(result.Distinct());
        }


    }
}