using System.ComponentModel.DataAnnotations;

namespace Resume.Domain.Models;

public class Information
{
    [Key]
    public long Id { get; set; }

    public string Avatar { get; set; }

    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; }
    
    [StringLength(100, MinimumLength = 3)]
    public string Job { get; set; }
    
    [StringLength(100, MinimumLength = 3)]
    public string DateOfBirth { get; set; }
    
    [StringLength(1000)]
    public string Address { get; set; }

    [StringLength(100)]
    public string EmailAddress { get; set; }

    [StringLength(100)]
    public string PhoeNumber { get; set; }

    [StringLength(100)]
    public string ResumeFile { get; set; }

    public string MapSrc { get; set; }
}