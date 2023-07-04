using System.ComponentModel.DataAnnotations;


namespace Music.Web.ViewModels.Account
{
    public class UserLoginViewmodel
    {
        [Display(Name = "نام کاربری")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکترهای {0} نمی تواند بیشتر از {1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Email { get; set; }


        [Display(Name = "کلمه عبور")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکترهای {0} نمی تواند بیشتر از {1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "مرا بخاطر بسپار ")]
        public bool RememberMe { get; set; }
    }
}