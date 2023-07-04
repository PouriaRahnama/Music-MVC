using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Music.Data
{
    public class Song: baseEntity
    {
        public int SingerId { get; set; }

        [Display(Name = "نام آهنگ")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string SongName { get; set; }

        [Display(Name = "نام فایل آهنگ")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string SongFileName { get; set; }

        [Display(Name = "نام تصویر آهنگ")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string SongImageName { get; set; }

        [Display(Name = "تاریخ ثبت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(6000, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Description { get; set; }

        [Display(Name = "فعال / غیرفعال")]
        public bool IsActive { get; set; }

        [Display(Name = "حذف شده / نشده")]
        public bool IsDelete { get; set; }

        public virtual Singer Singer { get; set; }


        public virtual ICollection<SongVisit> SongVisit { get; set; }


        public virtual ICollection<SongLike> SongLikes { get; set; }
    }
}
