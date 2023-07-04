using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Music.Data
{
    public class Singer : baseEntity
    {
        [Display(Name = "نام خواننده")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string SingerName { get; set; }

        [Display(Name = "تصویر خواننده")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string SingerImage { get; set; }

        [Display(Name = "فعال / غیرفعال")]
        public bool IsActive { get; set; }

        [Display(Name = "حذف شده / نشده")]
        public bool IsDelete { get; set; }

        public virtual List<Song> Songs { get; set; }


    }
}
