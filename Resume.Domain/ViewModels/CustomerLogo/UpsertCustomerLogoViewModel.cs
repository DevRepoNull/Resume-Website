using System.ComponentModel.DataAnnotations;

namespace Resume.Domain.ViewModels.CustomerLogo;

public class UpsertCustomerLogoViewModel
{
    public long Id { get; set; }

    [Display(Name = "لوگو")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string Logo { get; set; }

    [Display(Name = "توضیحات لوگو")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string LogoAlt { get; set; }

    [Display(Name = "لینک")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string Link { get; set; }

    [Display(Name = "اولویت")]
    public int Order { get; set; }
}