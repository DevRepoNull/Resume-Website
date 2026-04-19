using System.ComponentModel.DataAnnotations;

namespace Resume.Domain.ViewModels.Education;

public class UpsertEducationViewModel
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

    [Display(Name = "توضیحات")]
    [StringLength(1000, MinimumLength = 5, ErrorMessage = "{0} وارد شده نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string Description { get; set; }

    [Display(Name = "اولویت")]
    public int Order { get; set; }
}