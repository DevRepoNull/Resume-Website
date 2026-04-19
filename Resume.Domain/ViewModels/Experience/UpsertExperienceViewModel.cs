using System.ComponentModel.DataAnnotations;

namespace Resume.Domain.ViewModels.Experience;

public class UpsertExperienceViewModel
{
    public long Id { get; set; }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} وارد شده نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string Title { get; set; }

    [Display(Name = "تاریخ شروع")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [StringLength(4, MinimumLength = 4, ErrorMessage = "{0} وارد شده نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string StartDate { get; set; }

    [Display(Name = "تاریخ پایان")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [StringLength(4, MinimumLength = 4, ErrorMessage = "{0} وارد شده نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string EndDate { get; set; }

    [Display(Name = "جزئیات")]
    [StringLength(1000, MinimumLength = 5, ErrorMessage = "{0} وارد شده نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string Description { get; set; }

    [Display(Name = "اولویت")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public int Order { get; set; }
}