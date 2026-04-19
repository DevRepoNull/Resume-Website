using System.ComponentModel.DataAnnotations;

namespace Resume.Domain.Models;

public class Education
{
    [Key]
    public long Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Title { get; set; }

    [Required]
    [StringLength(4, MinimumLength = 4)]
    public string StartDate { get; set; }

    [Required]
    [StringLength(4, MinimumLength = 4)]
    public string EndDate { get; set; }

    [StringLength(1000, MinimumLength = 5)]
    public string Description { get; set; }

    public int Order { get; set; } = 0;
}