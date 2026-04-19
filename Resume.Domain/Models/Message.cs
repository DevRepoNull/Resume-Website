using System.ComponentModel.DataAnnotations;

namespace Resume.Domain.Models;

public class Message
{
    [Key]
    public long Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; }

    [Required]
    [StringLength(250, MinimumLength = 3)]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [StringLength(1000)]
    public string Text { get; set; }
}