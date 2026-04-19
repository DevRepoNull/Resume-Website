using System.ComponentModel.DataAnnotations;

namespace Resume.Domain.Models;

public class Skill
{
    [Key]
    public long Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Title { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string Percentage { get; set; }

    [Required]
    public int Order { get; set; } = 0;
}