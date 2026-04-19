using System.ComponentModel.DataAnnotations;

namespace Resume.Domain.ViewModels.Skill;

public class UpsertSkillViewModel
{
    public long Id { get; set; }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} وارد شده نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string Title { get; set; }

    [Display(Name = "درصد")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "{0} وارد شده نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string Percentage { get; set; }

    [Display(Name = "اولویت")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public int Order { get; set; }
}