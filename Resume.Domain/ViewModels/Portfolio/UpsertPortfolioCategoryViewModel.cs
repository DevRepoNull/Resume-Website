using System.ComponentModel.DataAnnotations;

namespace Resume.Domain.ViewModels.Portfolio;

public class UpsertPortfolioCategoryViewModel
{
    public long Id { get; set; }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} وارد شده نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string Title { get; set; }

    [Display(Name = "عنوان انگلیسی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} وارد شده نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string LatinTitle { get; set; }

    [Display(Name = "اولویت بندی")]
    public int Order { get; set; } = 0;
}