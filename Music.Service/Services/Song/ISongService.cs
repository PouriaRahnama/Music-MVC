using Music.Data;
using Music.Service.DTO_ViewModel_;
using System;
using System.Collections.Generic;


namespace Music.Service
{
    public interface ISongService : IDisposable
    {
        List<Song> GetAllSingerSongs(int singerId);
        void AddSong(Song song);
        Song GetSongById(int songId);
        void EditSong(Song song);
        List<Song> GetLatestSongsForHeader();

        List<Song> GetBySearch(string search);
        AllSongsDTO GetAllSongs(AllSongsDTO filter);
        SingleSongDTO GetSingleSong(int songId);

        bool IsExistSongById(int songId);
        bool HasUserLikedSong(int songId, string userIP);
        void DisLikeSong(int songId, string userIP);
        void LikeSong(int songId, string userIP);
        bool HasUserVisitedSong(int songId, string userIP);
        void AddVisitForSong(int songId, string userIP);
        List<Song> GetFavoritesSongs();
        List<Song> GetSongsOrderedByVisit();

    }
}
