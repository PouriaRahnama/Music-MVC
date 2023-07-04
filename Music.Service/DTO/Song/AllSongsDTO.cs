using Music.Data;
using Music.Service.DTO_ViewModel_.Paging;
using System.Collections.Generic;

namespace Music.Service.DTO_ViewModel_
{
    public class AllSongsDTO:BasePaging
    {
        public List<Song> Songs { get; set; }

        public AllSongsDTO SetSongs(List<Song> songs)
        {
            Songs = songs;

            return this;
        }

        public AllSongsDTO SetPaging(BasePaging paging)
        {
            PageId = paging.PageId;
            ActivePage = paging.ActivePage;
            PageCount = paging.PageCount;
            StartPage = paging.StartPage;
            EndPage = paging.EndPage;
            TakeEntity = paging.TakeEntity;
            SkipEntity = paging.SkipEntity;

            return this;
        }
    }
}
