using System.ComponentModel.DataAnnotations;

namespace Resume.Domain.Models;

public class SocialMedia
{
    [Key]
    public long Id { get; set; }

    [Required]
    [StringLength(1000)]
    public string Link { get; set; }

    [Required]
    [StringLength(100)]
    public string Icon { get; set; }

    public int Order { get; set; } = 0;
}