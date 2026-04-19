using System.ComponentModel.DataAnnotations;

namespace Resume.Domain.ViewModels.Information;

public class UpsertInformationViewModel
{
    public long Id { get; set; }

    [Display(Name = "عکس")]
    public string Avatar { get; set; }

    [Display(Name = "نام و نام خانوادگی")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} وارد شده نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string Name { get; set; }

    [Display(Name = "شغل")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} وارد شده نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string Job { get; set; }

    [Display(Name = "تاریخ تولد")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} وارد شده نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string DateOfBirth { get; set; }

    [Display(Name = "آدرس")]
    [StringLength(1000, ErrorMessage = "{0} وارد شده نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string Address { get; set; }

    [Display(Name = "ایمیل")]
    [StringLength(100, ErrorMessage = "{0} وارد شده نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string EmailAddress { get; set; }

    [Display(Name = "شماره تماس")]
    [StringLength(100, ErrorMessage = "{0} وارد شده نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string PhoeNumber { get; set; }

    [Display(Name = "فایل رزومه")]
    [StringLength(100)]
    public string ResumeFile { get; set; }

    [Display(Name = "آدرس نقشه")]
    public string MapSrc { get; set; }
}