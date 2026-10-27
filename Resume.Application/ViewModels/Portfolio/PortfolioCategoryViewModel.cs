using System.ComponentModel.DataAnnotations;

namespace Resume.Application.ViewModels.Portfolio;

public class PortfolioCategoryViewModel
{
    public long Id { get; set; }

    [Display(Name = "عنوان")]
    public string Title { get; set; }

    [Display(Name = "عنوان انگلیسی")]
    public string LatinTitle { get; set; }

    [Display(Name = "اولویت بندی")]
    public int Order { get; set; } = 0;
}