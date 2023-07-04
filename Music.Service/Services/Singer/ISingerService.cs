using Music.Data;
using System;
using System.Collections.Generic;

namespace Music.Service
{
    public interface ISingerService:IDisposable
    {

        List<Singer> GetAllSingers();

        void AddSinger(Singer singer);

        Singer GetSingerById(int singerId);

        void EditSinger(Singer singer);


    }
}
