using Music.Data;
using System.Collections.Generic;

namespace Music.Service.DTO_ViewModel_
{
    public class SingleSongDTO
    {
        public Song Song { get; set; }

        public List<Song> Songs { get; set; }
    }
}
