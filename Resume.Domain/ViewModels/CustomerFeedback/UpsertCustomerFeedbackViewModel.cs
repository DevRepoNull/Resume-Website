using System.ComponentModel.DataAnnotations;

namespace Resume.Domain.ViewModels.CustomerFeedback;

public class UpsertCustomerFeedbackViewModel
{
    public long Id { get; set; }

    [Display(Name = "آواتار کاربر")]
    public string Avatar { get; set; }

    [Display(Name = "نام کاربر")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} وارد شده نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string Name { get; set; }

    [Display(Name = "توضیحات")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [StringLength(1000, MinimumLength = 10, ErrorMessage = "{0} وارد شده نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string Description { get; set; }

    [Display(Name = "اولویت")]
    public int Order { get; set; }
}