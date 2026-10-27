using Microsoft.EntityFrameworkCore;
using Resume.Domain.Models;

namespace Resume.Application.Context;

public interface IAppDbContext
{
    DbSet<ThingIDo> ThingIDos { get; set; }
    DbSet<CustomerFeedback> CustomerFeedbacks { get; set; }
    DbSet<CustomerLogo> CustomerLogos { get; set; }
    DbSet<Education> Educations { get; set; }
    DbSet<Experience> Experiences { get; set; }
    DbSet<Skill> Skills { get; set; }
    DbSet<Portfolio> Portfolios { get; set; }
    DbSet<PortfolioCategory> PortfolioCategories { get; set; }
    DbSet<SocialMedia> SocialMedias { get; set; }
    DbSet<Information> Informations { get; set; }
    DbSet<Message> Messages { get; set; }
    DbSet<User> Users { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
