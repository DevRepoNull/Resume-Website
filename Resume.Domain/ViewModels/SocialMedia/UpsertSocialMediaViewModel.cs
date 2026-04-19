using System.ComponentModel.DataAnnotations;

namespace Resume.Domain.ViewModels.SocialMedia;

public class UpsertSocialMediaViewModel
{
    public long Id { get; set; }

    [Display(Name = "لینک")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [StringLength(1000, ErrorMessage = "{0} وارد شده نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string Link { get; set; }

    [Display(Name = "آیکن")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} وارد شده نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string Icon { get; set; }

    [Display(Name = "اولویت")]
    public int Order { get; set; }
}