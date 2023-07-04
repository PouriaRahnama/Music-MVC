using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Music.Data
{
    public class User : baseEntity
    {
        
        [Display(Name = "نام کاربری")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکترهای {0} نمی تواند بیشتر از {1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکترهای {0} نمی تواند بیشتر از {1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage ="ایمیل وارد شده معتبر نمی باشد.")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکترهای {0} نمی تواند بیشتر از {1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Password { get; set; }

        public bool IsDelete { get; set; }

        public string ActiveCode { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<UserRole> UserRoles{ get; set; }
    }
}
