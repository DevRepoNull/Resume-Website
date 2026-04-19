using System.ComponentModel.DataAnnotations;

namespace Resume.Domain.Models;

public class ThingIDo
{
    // Things IDo Properties

    [Key]
    public long Id { get; set; }

    [StringLength(50, MinimumLength = 8)]
    public string Icon { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Title { get; set; }

    [Required]
    [StringLength(1000, MinimumLength = 3)]
    public string Description { get; set; }

    [Range(4, 12)]
    public int ColumnLg { get; set; } = 6;

    public int Order { get; set; } = 0;
}