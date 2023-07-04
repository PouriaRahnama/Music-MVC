using Music.Data;
using System;
using System.Collections.Generic;


namespace Music.Service
{
    public interface ISliderService:IDisposable
    {
        void InsertSlider(Slider slider);
        List<Slider> GetAllSliders();
        Slider GetSliderById(int sliderId);      
        List<Slider> GetActivatedSliders();
        void EditSlider(Slider slider);
    }
}
