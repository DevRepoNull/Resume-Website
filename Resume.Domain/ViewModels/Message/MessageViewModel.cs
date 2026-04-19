using System.ComponentModel.DataAnnotations;

namespace Resume.Domain.ViewModels.Message;

public class MessageViewModel
{
    public long Id { get; set; }

    [Display(Name = "نام و نام خانوادگی")]
    public string Name { get; set; }

    [Display(Name = "ایمیل")]
    public string Email { get; set; }

    [Display(Name = "پیام")]
    public string Text { get; set; }
}