using System.ComponentModel.DataAnnotations;

namespace Resume.Domain.ViewModels.SocialMedia;

public class SocialMediaViewModel
{
    public long Id { get; set; }

    [Display(Name = "لینک")]
    public string Link { get; set; }

    [Display(Name = "آیکن")]
    public string Icon { get; set; }

    [Display(Name = "اولویت")]
    public int Order { get; set; } = 0;
}