using System.ComponentModel.DataAnnotations;

namespace Resume.Domain.ViewModels.CustomerFeedback;

public class CustomerFeedBackViewModel
{
    public long Id { get; set; }

    [Display(Name = "آواتار کاربر")]
    public string Avatar { get; set; }

    [Display(Name = "نام کاربر")]
    public string Name { get; set; }

    [Display(Name = "توضیحات")]
    public string Description { get; set; }

    [Display(Name = "اولویت")]
    public int Order { get; set; }
}