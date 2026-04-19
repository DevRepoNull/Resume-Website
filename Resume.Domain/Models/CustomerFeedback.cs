using System.ComponentModel.DataAnnotations;

namespace Resume.Domain.Models;

public class CustomerFeedback
{
    [Key]
    public long Id { get; set; }

    public string Avatar { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; }

    [Required]
    [StringLength(1000, MinimumLength = 10)]
    public string Description { get; set; }

    public int Order { get; set; } = 0;
}