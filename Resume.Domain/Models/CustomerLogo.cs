using System.ComponentModel.DataAnnotations;

namespace Resume.Domain.Models;

public class CustomerLogo
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string Logo { get; set; }

    [Required]
    public string LogoAlt { get; set; }

    [Required]
    public string Link { get; set; }

    public int Order { get; set; } = 0;
}