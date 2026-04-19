using System.ComponentModel.DataAnnotations;
using Resume.Domain.ViewModels.Common;

namespace Resume.Domain.ViewModels.Message;

public class CreateMessageViewModel : DntCaptchaViewModel
{
    [Display(Name = "نام و نام خانوادگی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} وارد شده نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string Name { get; set; }

    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [StringLength(250, MinimumLength = 3, ErrorMessage = "{0} وارد شده نمی تواند بیشتر از {1} کاراکتر باشد")]
    [EmailAddress(ErrorMessage = "لطفا ایمیل معتبر وارد کنید")]
    public string Email { get; set; }
    
    [Display(Name = "پیام")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [StringLength(1000, ErrorMessage = "{0} وارد شده نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string Text { get; set; }
}