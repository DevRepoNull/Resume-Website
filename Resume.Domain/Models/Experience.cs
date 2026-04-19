using System.ComponentModel.DataAnnotations;

namespace Resume.Domain.Models;

public class Experience
{
    [Key]
    public long Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Title { get; set; }

    [Required]
    [StringLength(5, MinimumLength = 5)]
    public string StartDate { get; set; }

    [Required]
    [StringLength(5, MinimumLength = 5)]
    public string EndDate { get; set; }

    [Required]
    [StringLength(1000, MinimumLength = 5)]
    public string Description { get; set; }

    [Required]
    public int Order { get; set; } = 0;
}