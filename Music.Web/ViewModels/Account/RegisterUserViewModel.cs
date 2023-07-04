using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Music.Web.ViewModels
{
    public class RegisterUserViewModel
    {

        [Display(Name ="نام کاربری")]
        [MaxLength(100,ErrorMessage ="تعداد کاراکترهای {0} نمی تواند بیشتر از {1} باشد")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [Remote("IsExistUseruserName", "Validate", ErrorMessage = "نام کاربری وارد شده از قبل موجود است ")]
        public string UserName { get; set; }


        [Display(Name ="ایمیل")]
        [MaxLength(100,ErrorMessage ="تعداد کاراکترهای {0} نمی تواند بیشتر از {1} باشد")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage ="ایمیل وارد شده معتبر نمی باشد")]
        [Remote("IsExistUserByEmail", "Validate",ErrorMessage ="ایمیل وارد شده از قبل موجود است ")]
        public string Email { get; set; }


        [Display(Name ="کلمه عبور")]
        [MaxLength(100,ErrorMessage ="تعداد کاراکترهای {0} نمی تواند بیشتر از {1} باشد")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name ="تکرار کلمه عبور")]
        [MaxLength(100,ErrorMessage ="تعداد کاراکترهای {0} نمی تواند بیشتر از {1} باشد")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [System.ComponentModel.DataAnnotations.Compare("Password",ErrorMessage ="کلمات عبور مغایرت دارند")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }

      
    }
    
}