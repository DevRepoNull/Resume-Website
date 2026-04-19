using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resume.Domain.ViewModels.Portfolio;

public class UpsertPortfolioViewModel
{
    public long Id { get; set; }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} وارد شده نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string Title { get; set; }

    [Display(Name = "لینک")]
    [StringLength(1000, ErrorMessage = "{0} وارد شده نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string Link { get; set; }

    [Display(Name = "عکس")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string Image { get; set; }

    [Display(Name = "توضیحات عکس")]
    public string AltImage { get; set; }

    [Display(Name = "اولویت")]
    public int Order { get; set; }

    [Display(Name = "دسته بندی گروه")]
    public long PortfolioCategoryId { get; set; }

    [NotMapped]
    public List<PortfolioCategoryViewModel> PortfolioCategory { get; set; }
}