using System.ComponentModel.DataAnnotations;

namespace Resume.Domain.ViewModels.Information;

public class InformationViewModel
{
    public long Id { get; set; }

    [Display(Name = "عکس")]
    public string Avatar { get; set; }

    [Display(Name = "نام و نام خانوادگی")]
    public string Name { get; set; }
    
    [Display(Name = "شغل")]
    public string Job { get; set; }
    
    [Display(Name = "تاریخ تولد")]
    public string DateOfBirth { get; set; }
    
    [Display(Name = "آدرس")]
    public string Address { get; set; }

    [Display(Name = "ایمیل")]
    public string EmailAddress { get; set; }

    [Display(Name = "شماره تماس")]
    public string PhoeNumber { get; set; }

    [Display(Name = "فایل رزومه")]
    public string ResumeFile { get; set; }

    [Display(Name = "آدرس نقشه")]
    public string MapSrc { get; set; }
}