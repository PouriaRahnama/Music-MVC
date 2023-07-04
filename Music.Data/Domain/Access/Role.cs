using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Music.Data
{
    public class Role : baseEntity
    {

        [Display(Name = "عنوان")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکترهای {0} نمی تواند بیشتر از {1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }

        [Display(Name = "نام سیستمی")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکترهای {0} نمی تواند بیشتر از {1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Name { get; set; }
     
        public bool IsDelete { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
