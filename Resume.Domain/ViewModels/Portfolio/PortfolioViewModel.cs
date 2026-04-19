using System.ComponentModel.DataAnnotations;

namespace Resume.Domain.ViewModels.Portfolio;

public class PortfolioViewModel
{
    public long Id { get; set; }

    [Display(Name = "عنوان")]
    public string Title { get; set; }

    [Display(Name = "لینک")]
    public string Link { get; set; }
    
    [Display(Name = "عکس")]
    public string Image { get; set; }

    [Display(Name = "توضیحات عکس")]
    public string AltImage { get; set; }

    [Display(Name = "اولویت")]
    public int Order { get; set; }

    [Display(Name = "دسته بندی گروه")]
    public string PortfolioCategoryLatinTitle { get; set; }
}