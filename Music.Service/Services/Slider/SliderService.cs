using Music.Data;
using Music.Repository;
using System.Collections.Generic;
using System.Linq;


namespace Music.Service
{
    public class SliderService : ISliderService
    {
        private IRepository<Slider> _sliderRepository;

        public SliderService(IRepository<Slider> sliderRepository)
        {
            this._sliderRepository = sliderRepository;
        }

        public void InsertSlider(Slider slider)
        {
            _sliderRepository.Insert(slider);
        }

        public List<Slider> GetAllSliders()
        {
            return _sliderRepository.Get(null).ToList();
        }

        public Slider GetSliderById(int sliderId)
        {
            return _sliderRepository.GetById(sliderId);
        }

        public void Dispose()
        {
            _sliderRepository.Dispose();
        }


        public void EditSlider(Slider slider)
        {
            _sliderRepository.Update(slider);
        }

        public List<Slider> GetActivatedSliders()
        {
            return _sliderRepository.Get(s => s.IsActive == true && s.IsDelete==false).ToList();
        }
    }
}
