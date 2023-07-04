using System.ComponentModel.DataAnnotations;

namespace Music.Service.DTO_ViewModel_.User
{
    public class AdminEditUserDto
    {
        public int UserId { get; set; }

        [Display(Name = "نام کاربری")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        public string Email { get; set; }

        public string CurrentEmail { get; set; }

        public string CurrentUserName { get; set; }

        [Display(Name = "فعال / غیرفعال")]
        public bool IsActive { get; set; }
    }
}
