using Music.Data;
using Music.Repository;
using System.Collections.Generic;
using System.Linq;


namespace Music.Service
{
    public class SingerService : ISingerService
    {
        private readonly IRepository<Singer> _singerRepository;
        public SingerService(IRepository<Singer> singerRepository)
        {
            _singerRepository = singerRepository;
        }


        public List<Singer> GetAllSingers()
        {
            List<Singer> Result = _singerRepository.Get(null).ToList();
            return Result;
        }

        public void AddSinger(Singer singer)
        {
            _singerRepository.Insert(singer);
        }

        public Singer GetSingerById(int singerId)
        {
            return _singerRepository.GetById(singerId);
        }

        public void EditSinger(Singer singer)
        {
            _singerRepository.Update(singer);
        }

        public void Dispose()
        {
            _singerRepository.Dispose();
        }
    }
}
