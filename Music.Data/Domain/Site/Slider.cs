using System.ComponentModel.DataAnnotations;


namespace Music.Data
{
    public class Slider : baseEntity
    {
        [Display(Name ="عنوان")]
        [MaxLength(100,ErrorMessage ="تعداد کاراکترهای {0} نمی تواند بیشتر از {1} باشد")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکترهای {0} نمی تواند بیشتر از {1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Description { get; set; }

        
        [MaxLength(100, ErrorMessage = "تعداد کاراکترهای {0} نمی تواند بیشتر از {1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ImageName { get; set; }

        [Display(Name = "فعال/غیر فعال")]
        public bool IsActive { get; set; }

        [Display(Name = "حذف شده/ نشده")]
        public bool IsDelete { get; set; }
    }
}
