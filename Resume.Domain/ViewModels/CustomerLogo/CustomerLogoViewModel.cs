using System.ComponentModel.DataAnnotations;

namespace Resume.Domain.ViewModels.CustomerLogo;

public class CustomerLogoViewModel
{
    public long Id { get; set; }

    [Display(Name = "لوگو")]
    public string Logo { get; set; }

    [Display(Name = "توضیحات لوگو")]
    public string LogoAlt { get; set; }

    [Display(Name = "لینک")]
    public string Link { get; set; }

    [Display(Name = "اولویت")]
    public int Order { get; set; }
}