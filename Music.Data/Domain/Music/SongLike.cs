using System.ComponentModel.DataAnnotations;


namespace Music.Data
{
    public class SongLike : baseEntity
    {
        public int SongId { get; set; }

        [MaxLength(50, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string UserIP { get; set; }

        public Song Song { get; set; }
    }
}
