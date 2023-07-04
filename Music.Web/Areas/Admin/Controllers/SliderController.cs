using System.Web;
using System.Web.Mvc;
using Music.Data;
using Music.Web.UnitOfWork;
using Music.Web.Utilities.ImageTools;

namespace Music.Web.Areas.Admin.Controllers
{
   
    public class SliderController : AdminBaseController
    {
        private IUnitOfWork unitOfWork;
        public SliderController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }



        public ActionResult Index()
        {
            return View(unitOfWork.SliderService.GetAllSliders());
        }



        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }



        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(Slider slider, HttpPostedFileBase sliderImage)
        {
            if (ModelState.IsValid)
            {
                if (sliderImage != null)
                {                   
                    sliderImage.AddImageToServer(sliderImage.FileName, ImagePath.SliderOriginalServerPath, 150, 150, ImagePath.SliderThumbServerPath);                   
                    unitOfWork.SliderService.InsertSlider(slider);
                    slider.ImageName = sliderImage.FileName;
                    unitOfWork.save();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(unitOfWork.SliderService.GetSliderById(id));
        }



        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Slider slider, HttpPostedFileBase sliderImage)
        {
            if (ModelState.IsValid)
            {
                if (sliderImage != null)
                {          
                    sliderImage.AddImageToServer(sliderImage.FileName, ImagePath.SliderOriginalServerPath, 150, 150, ImagePath.SliderThumbServerPath, slider.ImageName);
                    slider.ImageName = sliderImage.FileName;
                }
                unitOfWork.SliderService.EditSlider(slider);
                unitOfWork.save();
                return RedirectToAction("Index");
            }
            return View(slider);
        }



        public ActionResult Delete(int id)
        {
            var slider = unitOfWork.SliderService.GetSliderById(id);
            if (slider != null)
            {
                slider.IsDelete = true;
                unitOfWork.SliderService.EditSlider(slider);
                unitOfWork.save();
                return Json(new { status = "Done" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { status = "NotFound" }, JsonRequestBehavior.AllowGet);
        }



        public ActionResult Return(int id)
        {
            var slider = unitOfWork.SliderService.GetSliderById(id);
            if (slider != null)
            {
                slider.IsDelete = false;
                unitOfWork.SliderService.EditSlider(slider);
                unitOfWork.save();
                return Json(new { status = "Done" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { status = "NotFound" }, JsonRequestBehavior.AllowGet);
        }



    }
}