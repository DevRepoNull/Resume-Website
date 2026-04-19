using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resume.Domain.Models;

public class Portfolio
{
    [Key]
    public long Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Title { get; set; }

    [StringLength(1000)]
    public string Link { get; set; }

    [Required]
    public string Image { get; set; }

    public string AltImage { get; set; }

    public int Order { get; set; } = 0;

    // Relation one to many
    public long PortfolioCategoryId { get; set; }

    [ForeignKey(nameof(PortfolioCategoryId))]
    public PortfolioCategory PortfolioCategory { get; set; }
}

public class PortfolioCategory
{
    [Key]
    public long Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Title { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string LatinTitle { get; set; }

    public int Order { get; set; } = 0;

    public ICollection<Portfolio> Portfolios { get; set; }
}