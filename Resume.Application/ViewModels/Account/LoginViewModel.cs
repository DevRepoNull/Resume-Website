using System.ComponentModel.DataAnnotations;

namespace Resume.Application.ViewModels.Account;

public class LoginViewModel
{
    [Required(ErrorMessage = "لطفاً نام کاربری یا ایمیل را وارد کنید")]
    [Display(Name = "نام کاربری یا ایمیل")]
    [MaxLength(150, ErrorMessage = "حداکثر طول مجاز 150 کاراکتر است")]
    public string Username { get; set; }

    [Required(ErrorMessage = "لطفاً کلمه عبور را وارد کنید")]
    [DataType(DataType.Password)]
    [Display(Name = "کلمه عبور")]
    public string Password { get; set; }

    [Display(Name = "مرا به خاطر بسپار")]
    public bool RememberMe { get; set; }

    public string ReturnUrl { get; set; }
}
